using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public bool _shouldSpawn=true;
    [HideInInspector]
    public List<GameObject> _CultistsGMref;
    [SerializeField] private GameObjectEvent gameOverEvent;
    public Animator GlobalVolume;
    public Volume SuspicionStressVolume;
    public List<int> SatansWaves;
    public int SatanLive = 0;
    PlayerMovement player;
    SpawnBehaviour spawnBehaviour;
    public GameObject PrefabFummee;
    public GameObject CollidedCultist;
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
        StartCoroutine(StartWaves());
    }
    private void Start()
    {
        _CultistsGMref = new List<GameObject>();
        
    }

    public void ShakeCamera()
    {
        GameObject.FindFirstObjectByType<Camera>().transform.DOShakePosition(0.5f,0.5f);
    }

    IEnumerator StartWaves()
    {
        yield return new WaitForSecondsRealtime(6);
        spawnBehaviour.Init();
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
