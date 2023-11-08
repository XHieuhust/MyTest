using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene4Manager : MonoBehaviour
{
    public static GameScene4Manager ins;

    private void Start()
    {
        ins = this;
    }

    public void EndScene()
    {
        StartCoroutine(StartToNextScene());
    }

    IEnumerator StartToNextScene()
    {
        yield return new WaitForSeconds(0.5f);
        ScenesManager.ins.LoadScene("Scene5");
    }
}
