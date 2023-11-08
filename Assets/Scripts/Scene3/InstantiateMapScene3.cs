using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateMapScene3 : MonoBehaviour
{
    [SerializeField] List<Image> ListMap;
    private int numOfMap;
    void Start()
    {
        numOfMap = ListMap.Count;
        LoadMap();
    }

    public void LoadMap()
    {
        int curMap = PlayerPrefs.GetInt("currentMap", 0);
        Image mapCur = Instantiate(ListMap[curMap % numOfMap], transform.position, Quaternion.identity);
        mapCur.transform.SetParent(transform, false);
    }
}
