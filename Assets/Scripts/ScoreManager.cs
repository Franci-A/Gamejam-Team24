using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float currentScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObjectEvent addScoreEvent;

    private void Start()
    {
        currentScore = 0;
        addScoreEvent.scriptableEvent.AddListener(AddScore);
        UpdateScore();
    }

    public void AddScore(object obj)
    {
        currentScore += (float)obj;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
