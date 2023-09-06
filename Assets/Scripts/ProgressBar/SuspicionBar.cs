using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionBar : MonoBehaviour
{
    [SerializeField] private GameObjectEvent lostCultist;
    private float totalValue;

    private void Start()
    {
        lostCultist.scriptableEvent.AddListener(AddSuspicion);
    }

    public void AddSuspicion(object obj)
    {
        float value = (float)obj;
        totalValue += value;
        Debug.Log("AddValue : " + value +" : Total value : " + totalValue);
    }

    private void OnDestroy()
    {
        lostCultist.scriptableEvent.RemoveListener(AddSuspicion);

    }
}
