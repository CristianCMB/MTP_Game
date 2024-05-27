using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class TooltipUI : MonoBehaviour
{
    public static TooltipUI Instance { get; private set; }
    [SerializeField] private RectTransform canvasRectTransform;

    private TextMeshProUGUI textMeshPro;
    private RectTransform backgroundRectTransform;
    private RectTransform rectTransform;
    private TooltipTimer tooltipTimer;

    private void Awake() {
        Instance = this;
        textMeshPro = transform.Find("text").GetComponent<TextMeshProUGUI>();
        backgroundRectTransform= transform.Find("background").GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();

        Hide();
    }

    private void Update() {
        HandleFollowMouse();
        if (tooltipTimer != null) {
            tooltipTimer.timer -= Time.deltaTime;
            if (tooltipTimer.timer <= 0) {
                Hide();
            }
        }
    }

    private void HandleFollowMouse() {
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;

        if (anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width) {
            anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
        }

        if (anchoredPosition.y + backgroundRectTransform.rect.height > canvasRectTransform.rect.height) {
            anchoredPosition.y = canvasRectTransform.rect.height  - backgroundRectTransform.rect.height;
        }

        rectTransform.anchoredPosition = anchoredPosition;
    }

    private void SetText(string toolTipText) {
    textMeshPro.SetText(toolTipText);
    textMeshPro.ForceMeshUpdate();

    Vector2 textSize = textMeshPro.GetRenderedValues(false);
    Vector2 padding = new Vector2(8, 8);
    backgroundRectTransform.sizeDelta = textSize + padding;
    }

    public void Show(string toolTipText, TooltipTimer tooltipTimer = null) {
        this.tooltipTimer = tooltipTimer;
        gameObject.SetActive(true);
        SetText(toolTipText);
        HandleFollowMouse();
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public class TooltipTimer {
        public float timer;
    }
}
