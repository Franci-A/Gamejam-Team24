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
    }

    private void GameOver(object obj)
    {
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }
}
