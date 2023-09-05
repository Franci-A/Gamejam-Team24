using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public Transform[] spawnArray;
    public float spawnWaitTime;
    public float spawnWaitTimeMin;
    public float spawnWaitTimeMax;

    private int randomValuePosition;
    private int randomValueNumberOfCultist;

    public GameObject cultistPrefab;

    List<List<GameObject>> cultistList = new List<List<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        //Setup List Of List for stocking GameObject in column
        cultistList = new List<List<GameObject>>();
        for (int listNumber = 0; listNumber < 4; listNumber++)
        {
            cultistList.Add(new List<GameObject>());
        }

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
        randomValueNumberOfCultist = Random.Range(1, 5);
        
        for (int countCultistList = 0; countCultistList < 4; countCultistList++)
        {
            foreach(var valueOfItems in cultistList[countCultistList])
            {
                Debug.Log(countCultistList,valueOfItems);
                Debug.Log("==========================");
            }
            
        }
        for(var counterOfSpawningCultist = 0; counterOfSpawningCultist< randomValueNumberOfCultist; counterOfSpawningCultist++)
        {
            randomValuePosition = Random.Range(1, 5);
            var cultistPosition = spawnArray[randomValuePosition].transform.position;
            cultistList[randomValuePosition - 1].Add(Instantiate(cultistPrefab, cultistPosition, Quaternion.identity) as GameObject);
        }
        spawnWaitTime = Random.Range(spawnWaitTimeMin, spawnWaitTimeMax);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    IEnumerator CultistSpawnTimer(float spawnWaitTime)
    {
        yield return new WaitForSeconds(spawnWaitTime);
        CultistSpawn();
    }
}
