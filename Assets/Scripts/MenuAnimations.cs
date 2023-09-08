using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI insertCoinText;

    private void Start()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(insertCoinText.DOColor(Color.white, .1f));
        seq.Insert(2.5f, insertCoinText.DOColor(Color.clear, .1f));
        seq.Insert(3, insertCoinText.DOColor(Color.white, .1f));
        seq.SetLoops(-1);
        seq.Play();
    }
}
