using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    bool isMoving;
    [SerializeField] float timeMove;
    IEnumerator co;
    public void Move(int newRow, int newCol, Vector3 newPos)
    {
        co = MoveToNewPosition(newRow, newCol, newPos);
        StartCoroutine(co);
    }
    
    IEnumerator MoveToNewPosition(int newRow, int newCol, Vector3 newPos)
    {
        bool canMove = Map.ins.CanMove[newRow, newCol] == 1 ? true : false;
        int oldRow = Map.ins.cellOnCar.indexRow;
        int oldCol = Map.ins.cellOnCar.indexCol;
        if (Mathf.Abs(newRow - oldRow) + Mathf.Abs(newCol - oldCol) == 1 && canMove && !isMoving)
        {
            int newRotation = (newCol - oldCol) * 90 + (newRow - oldRow == -1 ? 180 : 0);
            transform.eulerAngles = new Vector3(0, 0, newRotation);
            isMoving = true;
            float elapsedTime = 0;
            Vector3 startingPos = transform.position;
            while (elapsedTime < timeMove)
            {
                transform.position = Vector3.Lerp(startingPos, newPos, (elapsedTime / timeMove));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.position = newPos;
            isMoving = false;
            Map.ins.UpdatePositionCar(newRow, newCol);
            Map.ins.cam.UpdateCameraPos(newCol);
        }

    }

    public void MoveBackBridge()
    {
        StopCoroutine(co);
        transform.position = Map.ins.MatrixCells[2, 4].transform.position;
        Map.ins.cellOnCar = Map.ins.MatrixCells[2, 4];
        isMoving = false;
    }
}
