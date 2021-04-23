using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
public class TooltipController : MonoBehaviour
{
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    private CanvasGroup canvasGroup;
    public void OnPointerEnter()
    {
        canvasGroup.DOFade(1, 0.2f);
    }

    public void OnPointerExit()
    {
        canvasGroup.DOFade(0, 0.4f);
    }
}
