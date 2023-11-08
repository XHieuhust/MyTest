
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListObsacle : MonoBehaviour
{
    [SerializeField] List<GameObject> ListObsacles;
    [SerializeField] List<Transform> ListTransform;

    private void Awake()
    {
        int maxNumber = ListTransform.Count;
        List<int> Array = new List<int>(maxNumber);
        for (int i = 0; i < maxNumber; ++i)
        {
            Array.Add(i);
        }

        MixArray(Array);

        int cnt = 0;
        foreach (GameObject Obsacle in ListObsacles)
        {
            Instantiate(Obsacle, ListTransform[Array[cnt++]].position, Quaternion.identity);
        }
    }

    void MixArray(List<int> Array)
    {
        for (int i = 0; i < Array.Count; ++i)
        {
            int rand = Random.Range(0, Array.Count - 1);
            int tmp = Array[i];
            Array[i] = Array[rand];
            Array[rand] = tmp;

        }
    }
}
