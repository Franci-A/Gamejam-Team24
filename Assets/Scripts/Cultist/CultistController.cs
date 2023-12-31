using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CultistController : MonoBehaviour
{
    [HideInInspector]
    public float baseSpeed = 1;
    [SerializeField] public Vector3 direction = new Vector3(0, 0 , -1);
    private float timer = 0;
    private bool SHouldImpareSatanMovements = false;
    [SerializeField] private GameObject canvasParent;
    [SerializeField] private Image timerImage;
    [SerializeField] private Animator animator;
    [HideInInspector] public bool isInDialog = false;
    [HideInInspector] public bool isDialogDone = false;
    private int currentInput;
    private int indexLeft;

    private float totalPrize;
    private int totalInputs;
    private float cultistValue;
    private float suspicionValue;
    private float cultistTimer;
    private GameManager gameManager;

    [SerializeField] private Image iconPrefab;
    [SerializeField] private RectTransform iconParent;
    [SerializeField] private Sprite[] iconSprites;
    private int[] iconsList;
    private List<Image> iconsImages = new List<Image>();
    [HideInInspector]
    public int ID;

    [Header("Events")]
    [SerializeField] private GameObjectEvent lostEvent;
    [SerializeField] private GameObjectEvent joinedEvent;
    [SerializeField] private GameObjectEvent scoreEvent;

    public List<CultistsPreset> _CultistPresets;

    private bool isActive = false;

    [Header("Walk")]
    [SerializeField] private float lookInfrontDistance = 1f;
    [SerializeField] private Vector2 hitSize;
    [SerializeField] private LayerMask enemyMask;


    public void Init(int cultistID)
    {
        ID = cultistID;
        totalPrize = _CultistPresets[cultistID].CultistPrize;
        cultistValue = _CultistPresets[cultistID].CultistLevel;
        suspicionValue = _CultistPresets[cultistID].SuspicionLevel;
        cultistTimer = _CultistPresets[cultistID].CultistTime;

        if (ID != 4) totalInputs = Random.Range(_CultistPresets[cultistID].MinNumberOfSymbols, _CultistPresets[cultistID].MaxNumberOfSymbols);
        else totalInputs = gameManager.SatansWaves[gameManager.SatanLive];
        iconsList = new int[totalInputs];
        indexLeft = totalInputs - 1;
        for (int i = totalInputs-1; i >= 0; i--)
        {
            Image icon = Instantiate<Image>(iconPrefab, iconParent.transform);
            icon.rectTransform.DOLocalMoveY(-10 * i, .1f);
            int symbol = Random.Range(0, 4);
            if (ID == 3)
            {
                if(i == 0)
                {
                    symbol = Random.Range(4, 6);
                }
                else
                {
                    symbol = Random.Range(0, 6);
                }
            }
            if (ID == 2)
            {
                symbol = 5;
            }
            
            iconsList[i] = symbol;
            Debug.Log($"[{string.Join(",", iconsList)}]");
            icon.sprite = iconSprites[symbol];
            iconsImages.Add(icon);
        }

        timer = cultistTimer;

        baseSpeed = Random.Range(_CultistPresets[cultistID].MinSpeed, _CultistPresets[cultistID].MaxSpeed);

        timerImage.fillAmount = 1;
        canvasParent.SetActive(false);
        if(animator == null) animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        
        animator.SetFloat("Index", (float)cultistID);
        if (ID != 4) gameManager._CultistsGMref.Add(this.gameObject);
        else
        {
            gameObject.AddComponent<SatanController>();
            SHouldImpareSatanMovements = true;
        }
        isActive = true;
    }

    void Update()
    {
        if (!isActive)
            return;

        if (!isInDialog)
        {
            Walking();
        }
        else if(!isDialogDone)
        {
            timer -= Time.deltaTime;
            timerImage.fillAmount = timer/cultistTimer;
            if(timer <= 0)
            {
                FailedDialog();
            }
        }
    }
    void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Walking()
    {
        RaycastHit2D[] hit = Physics2D.CapsuleCastAll(transform.position, hitSize, CapsuleDirection2D.Horizontal, 0, Vector2.down, lookInfrontDistance, enemyMask);
        bool hasHit = false;
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.gameObject != gameObject)
            {
                Vector2 dis = hit[i].collider.transform.position - transform.position;

                direction = new Vector3(Mathf.Sign(dis.x) * -1, -1, 0).normalized;

                hasHit = true;
            }
        }

        if (!hasHit)
        {
            if(!SHouldImpareSatanMovements) direction = new Vector3(0, -1, 0);
        }
        transform.position += direction * baseSpeed * Time.deltaTime;
    }

    public void StartDialog()
    {
        isInDialog = true;
        animator.SetBool("IsWalking", false);
        timer = cultistTimer;
        canvasParent.SetActive(true);
    }


    public bool CorrectInput(int input)
    {
        if (iconsList[currentInput] == input)
        {
            currentInput++;

            Sequence seq = DOTween.Sequence();
            seq.Append(iconsImages[indexLeft].rectTransform.DOLocalMoveX(20, .5f));
            seq.Append(iconsImages[indexLeft].DOColor(new Color(1,1,1,0), .5f));
            iconsImages.RemoveAt(indexLeft);
            indexLeft--;

            if (indexLeft < 0)
            {
                if(ID == 4)
                {
                    if(gameManager.SatanLive == gameManager.SatansWaves.Count - 1)
                    {
                        DialogFinished();
                        return false;
                    }
                    else
                    {
                        StartCoroutine(AngrySatan());
                    }
                    return false;
                }
                else
                {
                    DialogFinished();
                    return false;
                }
                
            }
            else 
            {
                for (int i = 0; i < indexLeft +1; i++)
                {
                    iconsImages[indexLeft - i].rectTransform.DOLocalMoveY(-10 * i, .5f);
                }
                SoundManager.instance.PlayClip("GoodMotif");
                return true;
            }
        }
        else
        {
            FailedDialog();
            return false;
        }
    }

    public void DialogFinished()
    {
        Debug.Log("All inputs done");
        canvasParent.SetActive(false);
        SoundManager.instance.PlayClip("WinAdept");
        this.tag = "NotEnnemy";
        if (ID!=4) animator.SetTrigger("Transform");
        joinedEvent?.scriptableEvent.Invoke(cultistValue);
        scoreEvent.scriptableEvent.Invoke(totalPrize);
        if(ID == 4)
        {
            gameManager._shouldSpawn = true;
            gameManager.SatanLive = 0;
            gameManager.GlobalVolume?.SetBool("DiableHere", false);
        }
        if(ID == 2) //policier
        {
            lostEvent.scriptableEvent?.Invoke(suspicionValue);
        }
        isDialogDone = true;
        if (ID != 4) {GameObject fumee =Instantiate(gameManager.PrefabFummee,transform);
        fumee.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);}
        else
        {
            SHouldImpareSatanMovements=false;
            isInDialog = false;
        }
    }

    IEnumerator AngrySatan()
    {
        GameManager.Instance.ShakeCamera();
        SoundManager.instance.PlayClip("AngrySatan");
        yield return new WaitForSeconds(1);
        gameManager.SatanLive++;
        this.Init(4);
        StartDialog();
        currentInput = 0;
    }
    public void FailedDialog()
    {
        Debug.Log("Failed");
        isInDialog = false;
        SHouldImpareSatanMovements = false;
        this.tag = "NotEnnemy";
        canvasParent.SetActive(false);
        lostEvent?.scriptableEvent.Invoke(cultistValue);
        if (animator!=null)animator.SetBool("IsWalking", true);
        SoundManager.instance.PlayClip("FailAdept");
        isDialogDone = true;
        if (ID == 4)
        {
            gameManager._shouldSpawn = true;
            gameManager.SatanLive = 0;
            gameManager.GlobalVolume?.SetBool("DiableHere", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndZone"))
        {
            
            Destroy(this.gameObject);
        }
    }
    private void OnDestroy()
    {
        gameManager._CultistsGMref.Remove(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        if (!isInDialog) 
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, hitSize.x);
            Gizmos.DrawWireSphere(transform.position + Vector3.down * lookInfrontDistance, hitSize.x);
            RaycastHit2D[] hit = Physics2D.CapsuleCastAll(transform.position, hitSize, CapsuleDirection2D.Horizontal, 0, Vector2.down, lookInfrontDistance, enemyMask);
        }
    }
}
