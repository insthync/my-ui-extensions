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

    private float showTime;
    private float hideTime;

    public void Show()
    {
        showTime = Time.time;
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, showDuration).SetEase(showEase);
    }

    public void Hide()
    {
        hideTime = Time.time;
        transform.localScale = Vector3.one;
        transform.DOScale(Vector3.zero, hideDuration).SetEase(hideEase).OnComplete(() =>
        {
            if (hideTime >= showTime)
                gameObject.SetActive(false);
        });
    }
}
