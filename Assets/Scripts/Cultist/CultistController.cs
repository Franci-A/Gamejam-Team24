using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CultistController : MonoBehaviour
{
    private float baseSpeed = 1;
    [SerializeField] private Vector3 direction = new Vector3(0, 0 , -1);
    private float timer = 0;
    [SerializeField] private GameObject canvasParent;
    [SerializeField] private Image timerImage;
    [SerializeField] private Animator animator;
    [HideInInspector] public bool isInDialog = false;
    [HideInInspector] public bool isDialogDone = false;
    private int currentInput;
    private int indexLeft;

    private float totalPrize;
    public string nameCultist;
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
        nameCultist = _CultistPresets[cultistID].CultistName;
        totalPrize = _CultistPresets[cultistID].CultistPrize;
        cultistValue = _CultistPresets[cultistID].CultistLevel;
        suspicionValue = _CultistPresets[cultistID].SuspicionLevel;
        cultistTimer = _CultistPresets[cultistID].CultistTime;

        totalInputs = Random.Range(_CultistPresets[cultistID].MinNumberOfSymbols, _CultistPresets[cultistID].MaxNumberOfSymbols);
        iconsList = new int[totalInputs];
        indexLeft = totalInputs - 1;
        for (int i = totalInputs-1; i >= 0; i--)
        {
            Image icon = Instantiate<Image>(iconPrefab, iconParent.transform);
            icon.rectTransform.DOLocalMoveY(-10 * i, .1f);
            int symbol = Random.Range(0, 4);
            iconsList[i] = symbol;
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
        //if (cultistID != 4) gameManager._CultistsGMref.Add(this.gameObject);
        //else gameObject.AddComponent<SatanController>();
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
            direction = new Vector3(0, -1, 0);
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
                DialogFinished();
                return false;
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
        Destroy(this.gameObject.GetComponent<Collider2D>());
        animator.SetTrigger("Transform");
        joinedEvent?.scriptableEvent.Invoke(cultistValue);
        scoreEvent.scriptableEvent.Invoke(totalPrize);
        isDialogDone = true;
    }

    public void FailedDialog()
    {
        Debug.Log("Failed");
        isInDialog = false;
        Destroy(this.gameObject.GetComponent<Collider2D>());
        canvasParent.SetActive(false);
        lostEvent?.scriptableEvent.Invoke(cultistValue);
        if (animator!=null)animator.SetBool("IsWalking", true);
        SoundManager.instance.PlayClip("FailAdept");
        isDialogDone = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndZone"))
        {
            Destroy(this.gameObject);
        }
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
