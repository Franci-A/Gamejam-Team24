using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;

    public bool _shouldSpawn;
    public List<GameObject> _CultistsGMref = new List<GameObject>();
    [SerializeField] private GameObjectEvent gameOverEvent;
    PlayerMovement player;
    SpawnBehaviour spawnBehaviour;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        gameOverEvent.scriptableEvent.AddListener(GameOver);
        player = FindObjectOfType<PlayerMovement>();
        spawnBehaviour = FindObjectOfType<SpawnBehaviour>();
    }

    private void GameOver(object obj)
    {
        player.enabled = false;
        spawnBehaviour.StopAllCoroutines();
        CultistController[] allCultist = FindObjectsOfType<CultistController>();
        for (int i = 0; i < allCultist.Length; i++)
        {
            Destroy(allCultist[i].gameObject);
        }
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }
}
