using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene3Manager : MonoBehaviour
{
    public static GameScene3Manager ins;

    public int cntCompleteTurn;
    private void Start()
    {
        ins = this;
    }

    public void UpdateCntCompleteTurn()
    {
        cntCompleteTurn++;
        if(cntCompleteTurn == 3)
        {
            ScenesManager.ins.LoadScene("Scene4");
        }
    }
}
