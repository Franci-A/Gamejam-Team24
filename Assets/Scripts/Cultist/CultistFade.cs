using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CultistFade : MonoBehaviour
{
    // Start is called before the first frame update
    void CultistEventCaller()
    {

            SoundManager.instance.PlayClip("WinAdept");
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.DOFade(0, 1).onComplete = Suicide;

    }
    void Suicide()
    {
        Destroy(this.gameObject);
    }
}
