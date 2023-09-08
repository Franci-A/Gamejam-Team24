using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionBar : MonoBehaviour
{
    [SerializeField] private GameObjectEvent failedCultist;
    [SerializeField] private GameObjectEvent cultistSacrifice;
    [SerializeField] private GameObjectEvent gameOver;
    private float currentValue;
    [SerializeField] private float totalValue = 100;

    [SerializeField] private Slider slider;
    [SerializeField] private SuspicionValues values;
    private float timer = 0;
    private bool isGameover = false;

    private void Start()
    {
        failedCultist.scriptableEvent.AddListener(AddSuspicion);
        cultistSacrifice.scriptableEvent.AddListener(Sacrifice);
        if(slider == null) slider = GetComponentInChildren<Slider>();
        currentValue = 0;
        UpdateSlider();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        currentValue += values.baseAddValue.Evaluate(timer / values.timeToReachMaxValue) *Time.deltaTime;

        UpdateSlider();
    }

    public void AddSuspicion(object obj)
    {
        if (obj != null)
        {
            currentValue += (float)obj;
        }
        else
        {
            currentValue += values.failedInput;
        }
            currentValue = Mathf.Clamp(currentValue, 0,100);
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = currentValue / totalValue;
        GameManager.Instance.SuspicionStressVolume.weight = slider.value+0.4f;
        if (currentValue >= totalValue && !isGameover)
        {
            isGameover = true;
            gameOver.scriptableEvent.Invoke(null);
        }
    }

    public void Sacrifice(object obj) //80% pour 100cult
    {
        float amount = (float)obj;
        currentValue -= Mathf.Lerp(0,80, amount / 100f);
        currentValue = Mathf.Clamp(currentValue, 0, 100);
        UpdateSlider();
    }

    private void OnDestroy()
    {
        failedCultist.scriptableEvent.RemoveListener(AddSuspicion);
    }
}
