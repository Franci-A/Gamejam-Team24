using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(menuName = "Float Scriptable")]
public class FloatScriptable : ScriptableObject
{
    private float value;

    public float Value => value;

    public UnityEvent OnValueChanged { get; private set; }

    public void SetValue(float val)
    {
        value = val;
        OnValueChanged?.Invoke();
    } 
}
