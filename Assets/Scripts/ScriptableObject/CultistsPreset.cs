using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

public class CultistsPreset : ScriptableObject
{
    public string CultistName;

    public int CultistPrize;

    public float SuspicionLevel;

    public float CultistLevel;

    public int MinNumberOfSymbols;

    public int MaxNumberOfSymbols;

    public float CultistTime;
}
