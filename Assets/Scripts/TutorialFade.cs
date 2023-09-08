using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFade : MonoBehaviour
{
    [SerializeField] private Image tutorial;
    [SerializeField] private Image lever;

    void Start()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(tutorial.DOColor(Color.white, .5f));
        seq.Insert(0, lever.DOColor(Color.white, .5f));
        seq.Insert(5, tutorial.DOColor(Color.clear, 1));
        seq.Insert(5, lever.DOColor(Color.clear, 1));
    }

}
