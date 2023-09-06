using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{
    [SerializeField] private GameObjectEvent lostCultist;
    private float currentValue;
    [SerializeField] private float totalValue = 100;

    [SerializeField] private Slider slider;

    private void Start()
    {
        lostCultist.scriptableEvent.AddListener(AddSuspicion);
        if(slider == null) slider = GetComponentInChildren<Slider>();
        currentValue = 0;
        slider.value = currentValue;
    }

    public void AddSuspicion(object obj)
    {
        float value = (float)obj;
        currentValue += value;
        slider.value = currentValue / totalValue;
        Debug.Log("AddValue : " + value +" : Total value : " + totalValue);
    }

    private void OnDestroy()
    {
        lostCultist.scriptableEvent.RemoveListener(AddSuspicion);

    }
}
