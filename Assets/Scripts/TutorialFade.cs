using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFade : MonoBehaviour
{

    void Start()
    {
        Image tutorial = GetComponentInChildren<Image>();
        Sequence seq = DOTween.Sequence();

        seq.Append(tutorial.DOColor(Color.white, .5f));
        seq.Insert(5, tutorial.DOColor(Color.clear, 1));
    }

}
