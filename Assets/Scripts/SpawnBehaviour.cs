using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public Transform[] spawnArray;
    public float spawnWaitTime;
    public float spawnWaitTimeMin;
    public float spawnWaitTimeMax;

    public GameObject cultistPrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnArray = GetComponentsInChildren<Transform>();
        Debug.Log(spawnArray);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CultistSpawn()
    {

        var cultistPosition = spawnArray[Random.Range(1,5)].transform.position;
        Debug.Log(cultistPosition);
        Instantiate(cultistPrefab, cultistPosition, Quaternion.identity);
        spawnWaitTime = Random.Range(spawnWaitTimeMin, spawnWaitTimeMax);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    IEnumerator CultistSpawnTimer(float spawnWaitTime)
    {
        yield return new WaitForSeconds(spawnWaitTime);
        CultistSpawn();
    }
}
