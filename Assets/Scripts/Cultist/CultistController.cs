using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private int currentInput;

    private float totalPrize;
    public string nameCultist;
    private int totalInputs;
    private float cultistValue;
    private float suspicionValue;
    private float cultistTimer;
    private GameManager gameManager;

    [SerializeField] private Image iconInstance;
    [SerializeField] private Sprite[] iconSprites;

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
        totalInputs = Random.Range(_CultistPresets[cultistID].MinNumberOfSymbols, _CultistPresets[cultistID].MaxNumberOfSymbols);
        cultistValue = _CultistPresets[cultistID].CultistLevel;
        suspicionValue = _CultistPresets[cultistID].SuspicionLevel;
        cultistTimer = _CultistPresets[cultistID].CultistTime;
        timer = cultistTimer;

        baseSpeed = Random.Range(_CultistPresets[cultistID].MinSpeed, _CultistPresets[cultistID].MaxSpeed);

        timerImage.fillAmount = 1;
        canvasParent.SetActive(false);
        if(animator == null) animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
        
        isActive = true;
        animator.SetFloat("Index", (float)cultistID);
        if (cultistID != 4) gameManager._CultistsGMref.Add(this.gameObject);
        else gameObject.AddComponent<SatanController>();
    }

    void Update()
    {
        if (!isActive)
            return;

        if (!isInDialog)
        {
            Walking();
        }
        else
        {
            timer -= Time.deltaTime;
            timerImage.fillAmount = timer/cultistTimer;
            if(timer <= 0)
            {
                FailedDialog();
            }
        }
    }
    void Start()
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
                /*RaycastHit2D[] hitsRight = Physics2D.CircleCastAll(transform.position + new Vector3(1.5f, -1, 0) * lookInfrontDistance, .2f, Vector2.down, 1f, enemyMask);
                RaycastHit2D[] hitsLeft = Physics2D.CircleCastAll(transform.position + new Vector3(-1.5f, -1, 0) * lookInfrontDistance, .2f , Vector2.down,  1f, enemyMask);
                Debug.DrawLine(transform.position, transform.position + new Vector3(-1.5f, -1, 0) * lookInfrontDistance, Color.green);
                if (hitsRight.Length == 0)
                {
                    direction = new Vector3(1, -1, 0).normalized;

                }
                else if (hitsLeft.Length == 0) 
                {
                    direction = new Vector3(-1, -1, 0).normalized;
                }
                else
                {
                    direction = Vector2.zero;
                }*/

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
        GetSymbole();
    }

    private void GetSymbole() 
    { 
        int symbol = Random.Range(0, 4);
        iconInstance.sprite = iconSprites[symbol];
        currentInput = symbol;
        switch (symbol)
        {
            case 0:
                Debug.Log("Spade + 1");
                break;
            case 1:
                Debug.Log("Heart + 2");
                break;
            case 2:
                Debug.Log("Diamond + 3");
                break;
            case 3:
                Debug.Log("Club + 4");
                break;
            default:
                break;
        }
    }

    public bool CorrectInput(int input)
    {
        if(currentInput == input)
        {
            Debug.Log("Correct input");
            
            totalInputs--;
            if (totalInputs <= 0)
            {
                DialogFinished();
                return false;
            }
            else 
            {
                SoundManager.instance.PlayClip("GoodMotif");
                GetSymbole();
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
