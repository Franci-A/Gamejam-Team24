using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultistController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 1;
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

    [SerializeField] private Image iconInstance;
    [SerializeField] private Sprite[] iconSprites;

    [Header("Events")]
    [SerializeField] private GameObjectEvent lostEvent;
    [SerializeField] private GameObjectEvent joinedEvent;
    [SerializeField] private GameObjectEvent scoreEvent;

    public List<CultistsPreset> _CultistPresets;

    private bool isActive = false;

    public void Init(int cultistID)
    {
        nameCultist = _CultistPresets[cultistID].CultistName;
        totalPrize = _CultistPresets[cultistID].CultistPrize;
        totalInputs = Random.Range(_CultistPresets[cultistID].MinNumberOfSymbols, _CultistPresets[cultistID].MaxNumberOfSymbols);
        cultistValue = _CultistPresets[cultistID].CultistLevel;
        suspicionValue = _CultistPresets[cultistID].SuspicionLevel;
        cultistTimer = _CultistPresets[cultistID].CultistTime;
        timer = cultistTimer;
        isActive = true;
        timerImage.fillAmount = 1;
        canvasParent.SetActive(false);
        if(animator == null) animator = GetComponent<Animator>();
        animator.SetBool("IsWalking", true);
    }

    void Update()
    {
        if (!isActive)
            return;

        if (!isInDialog)
        {
            transform.position += direction * baseSpeed * Time.deltaTime;
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
                SoundManager.instance.PlayClip("WinAdept");
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
        isInDialog = false;
        canvasParent.SetActive(false);
        Destroy(this.gameObject.GetComponent<Collider2D>());
        joinedEvent?.scriptableEvent.Invoke(cultistValue);
        animator.SetBool("IsWalking", true);
        scoreEvent.scriptableEvent.Invoke(totalPrize);
    }

    public void FailedDialog()
    {
        Debug.Log("Failed");
        isInDialog = false;
        Destroy(this.gameObject.GetComponent<Collider2D>());
        canvasParent.SetActive(false);
        lostEvent?.scriptableEvent.Invoke(cultistValue);
        animator.SetBool("IsWalking", true);
        SoundManager.instance.PlayClip("FailAdept");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndZone"))
        {
            Destroy(this.gameObject);
        }
    }

}
