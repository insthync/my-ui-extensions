using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleUIExtension : MonoBehaviour, IUIExtension
{
    public float showDuration = 0.5f;
    public Ease showEase = Ease.OutBack;
    public float hideDuration = 0.5f;
    public Ease hideEase = Ease.InBack;

    public void Show()
    {
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, showDuration).SetEase(showEase);
    }

    public void Hide()
    {
        transform.DOScale(Vector3.zero, hideDuration).SetEase(hideEase).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
