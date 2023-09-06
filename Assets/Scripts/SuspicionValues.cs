using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SuspicionValues")]
public class SuspicionValues : ScriptableObject
{
    public float failedInput = 5;
    public AnimationCurve baseAddValue;
    public float timeToReachMaxValue = 10;
}
