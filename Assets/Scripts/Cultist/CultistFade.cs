using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CultistFade : MonoBehaviour
{
    // Start is called before the first frame update
    void CultistEventCaller()
    {

            SoundManager.instance.PlayClip("WinAdept"); //;D
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            transform.parent.GetComponent<CultistController>().isInDialog = false;

    }
    void Suicide()
    {
        Destroy(this.gameObject);
    }
}
