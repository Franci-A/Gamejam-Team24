using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        MusicManager.instance.ChangeToMainMenu();
    }
    public void StartGame()
    { 
        SceneManager.LoadScene("GameScene");
    }
}
