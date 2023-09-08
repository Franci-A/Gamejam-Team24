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

    public int randomWaveID;
    [SerializeField] private int waveCount = 0;
    private int spawnCount = 0;
    private int numberOfSpawn;
    private int randomNumberOfCultists;
    private int randomNumberPosition;
    [SerializeField] private int minNumberOfSpawn;
    [SerializeField] private int maxNumberOfSpawn;
    [SerializeField] private float cultistDisplacementPosition;

    [SerializeField] private CultistController cultistPrefab;

    [SerializeField] private ScoreManager scoreScript;
    private int scoreCoef=0;
    private int scoreCoefCheck=1;
    private bool scoreBoolCheck = false;
    public int scoreLimit;

    public List<WavePreset> _WavePresets;

    public void Init()
    {
        Debug.Log(spawnArray);
        numberOfSpawn = _WavePresets[0].numberOfCultistsEachWaves;
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
        float[] listOfCultist = {pauvre,riche,police, joker, satan};


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
                    finalCultistID.Add(randomValueID);
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
        //TEST DU SCORE POUR VAGUE SATAN
        scoreCoef = Mathf.FloorToInt(scoreScript.currentScore);
        scoreCoef = scoreCoef / scoreLimit;

        if (scoreCoefCheck == scoreCoef)
        {
            scoreBoolCheck = true;
        }

        spawnCount += 1;

        if (waveCount >= 4 && spawnCount == numberOfSpawn)
        {
            waveCount += 1;
            if (scoreBoolCheck)
            {
                randomWaveID = 4; //wave id 4 -> vague satan
                scoreBoolCheck = false;
            }
            //SINON VAGUE NORMAL AUTRE QUE SATAN
            else
            {
                randomWaveID = Random.Range(0, 4);
            }
            numberOfSpawn = _WavePresets[randomWaveID].numberOfCultistsEachWaves;
            spawnCount = 0;
        }
        else if (spawnCount == numberOfSpawn)
        {
            waveCount += 1;
            if (waveCount < 5)
            {
                numberOfSpawn = _WavePresets[waveCount].numberOfCultistsEachWaves;
            }
            spawnCount = 0;
        }

        scoreCoefCheck = scoreCoef + 1;

        if (waveCount < 5)
        {
            randomWaveID = waveCount;
        }
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    IEnumerator CultistSpawnTimer(float spawnWaitTime)
    {
        randomNumberOfCultists = Random.Range(1, 5);

        

        List<int> finalCultistID = CultistChoiceAndProb(randomWaveID,randomNumberOfCultists);
        while(finalCultistID.Count == 0)
        {
            finalCultistID = CultistChoiceAndProb(randomWaveID,randomNumberOfCultists);
        }
        yield return new WaitUntil(() => GameManager.Instance._shouldSpawn);
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
            cultise.Init(finalCultistID[counterOfSpawningCultist]);
        }
        spawnWaitTime = Random.Range(spawnWaitTimeMin, spawnWaitTimeMax);
        yield return new WaitForSeconds(spawnWaitTime);
        CultistSpawn();
        
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(cultistPosition, circleRadius);
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
