using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateUIExtension : MonoBehaviour, IUIExtension
{
    public Vector3 showPosition;
    public float showDuration = 0.5f;
    public Ease showEase = Ease.OutBack;
    public Vector3 hidePosition;
    public float hideDuration = 0.5f;
    public Ease hideEase = Ease.InBack;

    public void Show()
    {
        gameObject.SetActive(true);
        (transform as RectTransform).anchoredPosition = hidePosition;
        (transform as RectTransform).DOAnchorPos(showPosition, showDuration).SetEase(showEase);
    }

    public void Hide()
    {
        (transform as RectTransform).anchoredPosition = showPosition;
        (transform as RectTransform).DOAnchorPos(hidePosition, hideDuration).SetEase(hideEase).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
