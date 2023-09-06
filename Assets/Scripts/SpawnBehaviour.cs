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

    private int randomNumberOfCultist;
    private int randomNumberPosition;
    [SerializeField] private float cultistDisplacementPosition;

    [SerializeField] private CultistController cultistPrefab;
    

    void Start()
    {

        Debug.Log(spawnArray);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    public void CultistSpawn()
    {
        randomNumberOfCultist = Random.Range(0, 4);
        
        for(var counterOfSpawningCultist = 0; counterOfSpawningCultist< randomNumberOfCultist; counterOfSpawningCultist++)
        {
            Collider2D cultistColliders;
            do
            {
                randomNumberPosition = Random.Range(0, 4);
                cultistPosition = spawnArray[randomNumberPosition].transform.position;
                cultistPosition.x = cultistPosition.x + Random.Range(-cultistDisplacementPosition , cultistDisplacementPosition);
                cultistColliders = Physics2D.OverlapCircle(cultistPosition, circleRadius, cultistMask);
            } while (cultistColliders != null);
            CultistController cultise = Instantiate<CultistController>(cultistPrefab, cultistPosition, Quaternion.identity); 
            cultise.Init(Random.Range(0, cultise._CultistPresets.Count - 1));
        }
        spawnWaitTime = Random.Range(spawnWaitTimeMin, spawnWaitTimeMax);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    IEnumerator CultistSpawnTimer(float spawnWaitTime)
    {
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
