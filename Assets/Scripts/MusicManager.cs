using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    [SerializeField] private AudioClip mainMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip devilMusic;
    [SerializeField] private AudioClip gameoverMusic;
    private AudioSource mainSource;

    [SerializeField] private GameObjectEvent gameover;

    private void Awake()
    {
        if(MusicManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        mainSource = GetComponent<AudioSource>();
        gameover.scriptableEvent.AddListener(ChangeToGameover);
    }

    private void ChangeToGameover(object obj)
    {
        mainSource.clip = gameoverMusic;
        mainSource.Play();
    }

    public void ChangeToMainMenu()
    {
        mainSource.clip = mainMusic;
        mainSource.Play();
    }

    public void ChangeToMainGame()
    {
        mainSource.clip = gameMusic;
        mainSource.Play();
    }
    
    public void ChangeToDevil()
    {
        mainSource.clip = devilMusic;
        mainSource.Play();
    }

}
