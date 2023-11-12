using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigame3_Scene3
{
    public class BgDetected : MonoBehaviour
    {
        RectTransform rectTransform;
        public void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            Canvas canvas = FindObjectOfType<Canvas>();
            float newScaleX = canvas.GetComponent<RectTransform>().rect.width / (rectTransform.rect.width);
            float newScaleY = canvas.GetComponent<RectTransform>().rect.height / (rectTransform.rect.height);
            if (newScaleX > 1 || newScaleY > 1)
            {
                float newScale = (newScaleX >= newScaleY ? newScaleX : newScaleY);
                rectTransform.localScale = new Vector3(newScale, newScale, 0);
            }

        }
    }


}

