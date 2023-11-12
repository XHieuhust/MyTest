using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSet : MonoBehaviour
{
    [SerializeField] float speed;
    int isCurBg = 0;
    [SerializeField] Image posCam1;
    [SerializeField] Image posCam2;
    [SerializeField] Image posCam3;

    public void UpdateCameraPos(int curCol)
    {
        if (curCol == 9 && isCurBg == 0)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam1.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }else if (curCol == 19 && isCurBg == 1)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam2.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }else if (curCol == 25 && isCurBg == 2)
        {
            isCurBg += 1;
            Vector3 newPos = new Vector3(posCam3.transform.position.x, transform.position.y, transform.position.z);
            StartCoroutine(MoveCam(newPos));
        }
    }

    IEnumerator MoveCam(Vector3 newPos)
    {
        Vector3 startingPos = transform.position;
        while (transform.position != newPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}

