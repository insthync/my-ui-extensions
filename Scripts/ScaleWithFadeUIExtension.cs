using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScaleWithFadeUIExtension : MonoBehaviour, IUIExtension
{
    public Image fadeImage;
    public CanvasGroup fadeGroup;
    public float showFadeDuration = 0.5f;
    public float showFadeAlpha = 0.5f;
    public float hideFadeDuration = 0.5f;
    public float hideFadeAlpha = 0;
    public Transform scaleTransform;
    public float showScaleDuration = 0.5f;
    public Ease showEase = Ease.OutBack;
    public Vector3 showScale = Vector3.one;
    public float hideScaleDuration = 0.5f;
    public Ease hideEase = Ease.InBack;
    public Vector3 hideScale = Vector3.zero;

    private float showTime;
    private float hideTime;

    public void Show()
    {
        showTime = Time.time;
        gameObject.SetActive(true);
        if (scaleTransform != null)
        {
            scaleTransform.localScale = hideScale;
            scaleTransform.DOScale(showScale, showScaleDuration).SetEase(showEase);
        }
        if (fadeImage != null)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, hideFadeAlpha);
            fadeImage.DOFade(showFadeAlpha, showFadeDuration);
        }
        if (fadeGroup != null)
        {
            fadeGroup.alpha = hideFadeAlpha;
            fadeGroup.DOFade(showFadeAlpha, showFadeDuration);
        }
    }

    public void Hide()
    {
        hideTime = Time.time;
        if (scaleTransform != null)
        {
            scaleTransform.localScale = showScale;
            scaleTransform.DOScale(hideScale, hideScaleDuration).SetEase(hideEase).OnComplete(() =>
            {
                if (hideTime >= showTime)
                    gameObject.SetActive(false);
            });
        }
        if (fadeImage != null)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, showFadeAlpha);
            fadeImage.DOFade(hideFadeAlpha, hideFadeDuration).OnComplete(() =>
            {
                if (hideTime >= showTime)
                    gameObject.SetActive(false);
            });
        }
        if (fadeGroup != null)
        {
            fadeGroup.alpha = showFadeAlpha;
            fadeGroup.DOFade(hideFadeAlpha, hideFadeDuration).OnComplete(() =>
            {
                if (hideTime >= showTime)
                    gameObject.SetActive(false);
            });
        }
    }
}
