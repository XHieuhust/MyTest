using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListHouse : MonoBehaviour
{
    [SerializeField] List<Sprite> spritesHouse;
    [SerializeField] List<GameObject> houses;

    private void Awake()
    {
        int cnt = 0;
        foreach(GameObject house in houses)
        {
            house.GetComponent<SpriteRenderer>().sprite = spritesHouse[cnt++];
        }
    }
}
