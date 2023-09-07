using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] spawnArray;
    private float spawnWaitTime;
    [SerializeField] private float spawnWaitTimeMin;
    [SerializeField] private float spawnWaitTimeMax;

    [SerializeField] private float circleRadius;

    [SerializeField] private LayerMask cultistMask;
    private Vector3 cultistPosition;

    private int randomWaveID;
    private int randomNumberOfCultists;
    private int randomNumberPosition;
    [SerializeField] private float cultistDisplacementPosition;

    [SerializeField] private CultistController cultistPrefab;

    public List<WavePreset> _WavePresets;


    void Start()
    {
        Debug.Log(spawnArray);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    private List<int> CultistChoiceAndProb(int waveID, int numberOfCultists)
    {
        WavePreset wave = _WavePresets[waveID];
        float pauvre = wave.typePauvreRate;
        float riche = wave.typeRicheRate;
        float joker = wave.typeJokerRate;
        float police = wave.typePoliceRate;
        float satan = wave.typeSatanRate;
        float[] listOfCultist = {pauvre,riche,joker,police,satan};


        int randomValueProb = Random.Range(1, 100);
        List<int> finalCultistID = new List<int>();
        int randomValueID;
        if (waveID != 4)
        {
            for (var i = 0; i < numberOfCultists + 1; i++)
            {
                randomValueID = Random.Range(0, 5);
                if (randomValueProb < listOfCultist[randomValueID])
                {
                    finalCultistID.Add(i);
                }
            }
        }
        else
        {
            finalCultistID.Add(4);
        }
        return finalCultistID;

    }

    public void CultistSpawn()
    {
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    IEnumerator CultistSpawnTimer(float spawnWaitTime)
    {
        randomWaveID = Random.Range(0, 5);
        randomNumberOfCultists = Random.Range(1, 5);
        List<int> finalCultistID = CultistChoiceAndProb(randomWaveID,randomNumberOfCultists);

        while(finalCultistID == null)
        {
            finalCultistID = CultistChoiceAndProb(randomWaveID,randomNumberOfCultists);
        }

        for (var counterOfSpawningCultist = 0; counterOfSpawningCultist < finalCultistID.Count; counterOfSpawningCultist++)
        {
            Collider2D cultistColliders;
            do
            {
                randomNumberPosition = Random.Range(0, 4);
                cultistPosition = spawnArray[randomNumberPosition].transform.position;
                cultistPosition.x = cultistPosition.x + Random.Range(-cultistDisplacementPosition, cultistDisplacementPosition);
                cultistColliders = Physics2D.OverlapCircle(cultistPosition, circleRadius, cultistMask);
                yield return new WaitForSeconds(0.2f);
            } while (cultistColliders != null);
            CultistController cultise = Instantiate<CultistController>(cultistPrefab, cultistPosition, Quaternion.identity);
            Debug.Log(finalCultistID[counterOfSpawningCultist]);
            cultise.Init(finalCultistID[counterOfSpawningCultist]);
        }
        spawnWaitTime = Random.Range(spawnWaitTimeMin, spawnWaitTimeMax);
        yield return new WaitForSeconds(spawnWaitTime);
        CultistSpawn();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(cultistPosition, circleRadius);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
