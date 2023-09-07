using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "WavePreset")]
public class WavePreset : ScriptableObject
{
    public int numberOfCultistsEachWaves;

    public float typePauvreRate;

    public float typeRicheRate;

    public float typePoliceRate;

    public float typeJokerRate;

    public float typeSatanRate;
}
