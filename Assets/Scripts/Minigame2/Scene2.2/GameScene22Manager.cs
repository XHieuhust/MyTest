using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene22Manager : MonoBehaviour
{
    public static GameScene22Manager ins;
    int cntTurn;
    [SerializeField] QuanLyTrangPhuc day1;
    [SerializeField] QuanLyTrangPhuc day2;

    private void Start()
    {
        ins = this;
        NextTurn();
    }

    public void UpdateTurn()
    {
        cntTurn++;
        if (cntTurn == 4)
        {
            EndScene();
        }
        else 
        {
            NextTurn();
        }
    }


    void NextTurn()
    {
        day1.isTrueTrangPhuc = false;
        day2.isTrueTrangPhuc = false;
        day2.InstantiateTrangPhuc(cntTurn);
        day1.InstantiateTrangPhuc(cntTurn);
    }

    void EndScene()
    {
        ScenesManager.ins.LoadScene("Scene23");
    }
}
