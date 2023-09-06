using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{
    [SerializeField] private GameObjectEvent failedCultist;
    private float currentValue;
    [SerializeField] private float totalValue = 100;

    [SerializeField] private Slider slider;
    [SerializeField] private SuspicionValues values;
    private float timer = 0;

    private void Start()
    {
        failedCultist.scriptableEvent.AddListener(AddSuspicion);
        if(slider == null) slider = GetComponentInChildren<Slider>();
        currentValue = 0;
        UpdateSlider();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        currentValue += values.baseAddValue.Evaluate(timer / values.timeToReachMaxValue);
        UpdateSlider();
    }

    public void AddSuspicion(object obj)
    {
        currentValue += values.failedInput;
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = currentValue / totalValue;
        if (currentValue >= totalValue)
            Debug.Log("game over");
    }

    private void OnDestroy()
    {
        failedCultist.scriptableEvent.RemoveListener(AddSuspicion);
    }
}
