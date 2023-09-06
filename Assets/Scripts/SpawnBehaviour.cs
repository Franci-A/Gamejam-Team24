using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] spawnArray;
    public float spawnWaitTime;
    public float spawnWaitTimeMin;
    public float spawnWaitTimeMax;

    [SerializeField] private float circleRadius;

    [SerializeField] private LayerMask cultistMask;
    private Vector3 cultistPosition;

    private int randomNumberOfCultist;

    public GameObject cultistPrefab;

    /*List<List<GameObject>> cultistList = new List<List<GameObject>>();*/

    // Start is called before the first frame update
    void Start()
    {
        /*
        //Setup List Of List for stocking GameObject in column
        cultistList = new List<List<GameObject>>();
        for (int listNumber = 0; listNumber < 4; listNumber++)
        {
            cultistList.Add(new List<GameObject>());
        }
        */

        Debug.Log(spawnArray);
        StartCoroutine(CultistSpawnTimer(spawnWaitTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CultistSpawn()
    {
        randomNumberOfCultist = Random.Range(0, 4);
        
        /*
        for (int countCultistList = 0; countCultistList < 4; countCultistList++)
        {
            foreach(var valueOfItems in cultistList[countCultistList])
            {
                Debug.Log(countCultistList,valueOfItems);
                Debug.Log("==========================");
            }
        }
        */
        for(var counterOfSpawningCultist = 0; counterOfSpawningCultist< randomNumberOfCultist; counterOfSpawningCultist++)
        {
            cultistPosition = new Vector3(Random.Range(spawnArray[0].transform.position.x, spawnArray[1].transform.position.x), spawnArray[0].transform.position.y, spawnArray[0].transform.position.z);

            var cultistColliders = Physics2D.OverlapCircle(cultistPosition, circleRadius, cultistMask);

            while(cultistColliders != null)
            {
                cultistPosition = new Vector3(Random.Range(spawnArray[0].transform.position.x, spawnArray[1].transform.position.x), spawnArray[0].transform.position.y, spawnArray[0].transform.position.z);
                cultistColliders = Physics2D.OverlapCircle(cultistPosition, circleRadius, cultistMask);
            }
            Instantiate(cultistPrefab, cultistPosition, Quaternion.identity);
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
