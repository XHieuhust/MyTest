using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroScenePanel : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(delegate
        {
            ScenesManager.ins.LoadScene("SceneMenu");
        });
    }
}
