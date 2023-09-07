using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatanController : MonoBehaviour
{
    GameManager gameManager;
    private GameObject Player;
    private CultistController Satan;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager._shouldSpawn = false;
        gameManager.GlobalVolume.SetBool("DiableHere", true);
        Satan = gameObject.GetComponent<CultistController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        foreach (GameObject cultiste in gameManager._CultistsGMref)
        {
            CultistController Ccontroller = cultiste.GetComponent<CultistController>();
            Destroy(cultiste.GetComponent<BoxCollider2D>());
            Ccontroller.baseSpeed = 10;
        }
    }
    private void Update()
    {
        Satan.direction = (Player.transform.position-this.transform.position).normalized;
    }

    private void OnDestroy()
    {
        gameManager._shouldSpawn = true;
        gameManager.SatanLive = 0;
        gameManager.GlobalVolume?.SetBool("DiableHere", false);
    }
}
