using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    public bool _shouldSpawn=true;
    [HideInInspector]
    public List<GameObject> _CultistsGMref;
    public Animator GlobalVolume;
    public List<int> SatansWaves;
    public int SatanLive = 0;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Start()
    {
        _CultistsGMref = new List<GameObject>();
    }
}
