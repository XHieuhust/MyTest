using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene5Manager : MonoBehaviour
{
    public static GameScene5Manager ins;
    public bool isPlayerbeHitted;
    public bool isThiefStartToRun;
    public bool isPlayerStartToRun;
    public int vpAnDuoc;
    [SerializeField] public GameObject tuiSao;
    [SerializeField] public GameObject bar;
    [SerializeField] public int completeVp;
    
    private void Start()
    {
        ins = this;
    }

    public void UpdateVpAnDuoc()
    {
        vpAnDuoc++;
        if (vpAnDuoc == completeVp)
        {
            GameManager.ins.CompleteMap();
            StartCoroutine(EndScene());
        }
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.5f);
        ScenesManager.ins.LoadScene("Scene1");
    }
}
