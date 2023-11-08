using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager ins;
    void Awake()
    {
        ins = this;
    }

    public void CompleteMap()
    {
        int nextMap = PlayerPrefs.GetInt("currentMap");
        PlayerPrefs.SetInt("currentMap", nextMap + 1);
    }

    public int GetCurrentMap()
    {
        int curMap = PlayerPrefs.GetInt("currentMap", 0);
       
        return curMap;
    }

}
