using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CultistController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 1;
    [SerializeField] private Vector3 direction = new Vector3(0, 0 , -1);
    [SerializeField] private float talkTime = 3;
    private float timer = 0;
    public bool isInDialog = false;
    private int currentInput;
    private int totalPrize;
    private int totalInputs;
    private float cultistValue;
    private float suspicionValue;
    private float cultistTimer;

    [SerializeField] private Image iconInstance;
    [SerializeField] private Sprite[] iconSprites;
    [SerializeField] private GameObjectEvent lostEvent;
    [SerializeField] private GameObjectEvent joinedEvent;
    public List<CultistsPreset> _CultistPresets;

    public void Init(CultistsPreset cultistStats)
    {
        totalPrize = cultistStats.CultistPrize;
        totalInputs = Random.Range(cultistStats.MinNumberOfSymbols, cultistStats.MaxNumberOfSymbols);
        cultistValue = cultistStats.CultistLevel;
        suspicionValue = cultistStats.SuspicionLevel;
        cultistTimer = cultistStats.CultistTime;
    }

    void Update()
    {
        if (!isInDialog)
        {
            transform.position += direction * baseSpeed * Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                FailedDialog();
            }
        }
    }

    public void StartDialog()
    {
        isInDialog = true;
        timer = talkTime;
        GetSymbole();
    }

    private void GetSymbole() 
    { 
        int symbol = Random.Range(0, 4);
        iconInstance.sprite = iconSprites[symbol];
        iconInstance.gameObject.SetActive(true);
        switch (symbol)
        {
            case 0:
                Debug.Log("Spade");
                break;
            case 1:
                Debug.Log("Heart");
                break;
            case 2:
                Debug.Log("Diamond");
                break;
            case 3:
                Debug.Log("Club");
                break;
            default:
                break;
        }
    }

    public void WaitInput(int input)
    {
        if(currentInput == input)
        {
            Debug.Log("Correct input");
            
            totalInputs--;
            if (totalInputs <= 0)
            {
                DialogFinished();
                SoundManager.instance.PlayClip("WinAdept");
            }
            else 
            {
                SoundManager.instance.PlayClip("GoodMotif");
                GetSymbole();
            }
        }
        else
        {
            FailedDialog();
        }
    }

    public void DialogFinished()
    {
        Debug.Log("All inputs done");
        isInDialog = false;
        iconInstance.gameObject.SetActive(false);
        joinedEvent?.scriptableEvent.Invoke(totalPrize);
    }

    public void FailedDialog()
    {
        Debug.Log("Failed");
        SoundManager.instance.PlayClip("FailAdept");
        isInDialog = false;
        lostEvent?.scriptableEvent.Invoke(cultistValue);
        Destroy(this.gameObject.GetComponent<Collider2D>());
        iconInstance.gameObject.SetActive(false);
    }
    
    public void MissedCultist()
    {
        Debug.Log("Missed");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndZone"))
        {
            MissedCultist();
        }
    }

}
