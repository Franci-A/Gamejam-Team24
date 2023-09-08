using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public float currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObjectEvent addScoreEvent;
    [SerializeField] private FloatScriptable scoreMultiplier;

    [SerializeField] private Animator moneyUp;
    [SerializeField] private Animator moneyDown;

    private void Start()
    {
        currentScore = 0;
        addScoreEvent.scriptableEvent.AddListener(AddScore);
        UpdateScore();
    }

    public void AddScore(object obj)
    {
        currentScore += (float)obj * scoreMultiplier.Value;
        UpdateScore();
        if(Mathf.Sign((float)obj) > 0)
        {
            moneyUp.SetTrigger("Play");
        }
        else
        {
            moneyDown.SetTrigger("Play");
        }
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
