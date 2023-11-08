using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgDetected : MonoBehaviour
{
    RectTransform rectTransform;
    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Canvas canvas = FindObjectOfType<Canvas>();
        rectTransform.localScale = new Vector3(canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width),
        canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width));
    }
}
