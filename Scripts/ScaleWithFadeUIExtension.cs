using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScaleWithFadeUIExtension : MonoBehaviour, IUIExtension
{
    public Image fadeImage;
    public float showFadeDuration = 0.5f;
    public float showFadeAlpha = 0.5f;
    public float hideFadeDuration = 0.5f;
    public float hideFadeAlpha = 0;
    public Transform scaleTransform;
    public float showScaleDuration = 0.5f;
    public Ease showEase = Ease.OutBack;
    public float hideScaleDuration = 0.5f;
    public Ease hideEase = Ease.InBack;

    public void Show()
    {
        gameObject.SetActive(true);
        scaleTransform.localScale = Vector3.zero;
        scaleTransform.DOScale(Vector3.one, showScaleDuration).SetEase(showEase);
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, hideFadeAlpha);
        fadeImage.DOFade(showFadeAlpha, showFadeDuration);
    }

    public void Hide()
    {
        scaleTransform.localScale = Vector3.one;
        scaleTransform.DOScale(Vector3.zero, hideScaleDuration).SetEase(hideEase).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
        fadeImage.DOFade(hideFadeAlpha, hideFadeDuration);
    }
}
