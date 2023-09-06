using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName ="EventObject")]
public class GameObjectEvent: ScriptableObject
{
    public UnityEvent<object> scriptableEvent;
}