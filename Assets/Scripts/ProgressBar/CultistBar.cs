using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CultistBar : MonoBehaviour
{
    [SerializeField] private GameObjectEvent cultistJoined;
    private float currentValue;
    [SerializeField] private float totalValue = 100;
    [SerializeField] private Slider slider;
    private float timer = 0;
    [SerializeField] private List<CultistScoreMultiplier> scores;
    [SerializeField] private FloatScriptable scoreMultiplier;

    private void Start()
    {
        cultistJoined.scriptableEvent.AddListener(AddCultist);
        if (slider == null) slider = GetComponentInChildren<Slider>();
        currentValue = 0;
        scores = scores.OrderByDescending(x => x.percentageNeeded).ToList();
        UpdateSlider();
    }

    private void Update()
    {
        UpdateSlider();
    }

    public void AddCultist(object obj)
    {
        float value = (float)obj;
        currentValue += value;
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        float percentage = currentValue / totalValue;
        slider.value = percentage;
        for (int i = 0; i < scores.Count; i++)
        {
            if(percentage >= scores[i].percentageNeeded)
            {
                scoreMultiplier.SetValue(scores[i].multiplierGiven);
                return;
            }
        }
        scoreMultiplier.SetValue(1);
    }

    private void OnDestroy()
    {
        cultistJoined.scriptableEvent.RemoveListener(AddCultist);
    }
}

[Serializable]
public class CultistScoreMultiplier
{
    public float percentageNeeded;
    public float multiplierGiven;
}
