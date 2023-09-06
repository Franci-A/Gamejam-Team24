using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

public class CultistsPreset : ScriptableObject
{
    public string CultistName;

    public int CultistPrizz;

    public float SuspicionLevel;

    public float CultistLevel;

    public int NumberOfSymbols;

    public float CultistTime;
}
