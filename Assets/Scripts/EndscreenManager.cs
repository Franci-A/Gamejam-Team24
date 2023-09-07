using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndscreenManager : MonoBehaviour
{
    private bool canContinue = false;
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        Color bgColor = background.color;
        background.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0);
        text.color = new Color(1,1,1, 0);
        Sequence seq = DOTween.Sequence();
        seq.Append(background.DOColor(bgColor, 1));
        seq.Append(text.DOColor(Color.white, 2));
        seq.onComplete += CanContinue;
    }

    private void CanContinue()
    {
        canContinue = true;
    }

    public void ReturnToMenu()
    {
        if (!canContinue) return;

        SceneManager.LoadScene("MainMenu");
    }
}
