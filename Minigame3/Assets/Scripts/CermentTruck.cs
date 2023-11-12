using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CermentTruck : MonoBehaviour
{
    Vector3 startPos;
    private void OnEnable()
    {
        startPos = transform.position;
        StartCoroutine(MoveFixed(Map.ins.rowHole, Map.ins.colHole));
    }

    IEnumerator MoveFixed(int rowHole, int ColHole)
    {
        Vector3 goalPos = Map.ins.MatrixCells[rowHole, ColHole].transform.position;
        float timeMove = 1f;
        float timeFixed = 0.5f;
        float elapsedTime = 0;
        // Move to Hole
        while (elapsedTime < timeMove)
        {
            transform.position = Vector3.Lerp(startPos, goalPos, (elapsedTime / timeMove));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = goalPos;
        yield return new WaitForSeconds(timeFixed);

        Map.ins.FixedHole();

        //Move Back
        elapsedTime = 0;
        transform.eulerAngles = new Vector3(0, 0, 0);
        while (elapsedTime < timeMove)
        {
            transform.position = Vector3.Lerp(goalPos, startPos, (elapsedTime / timeMove));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = startPos;
        Destroy(gameObject);    
    }
}
