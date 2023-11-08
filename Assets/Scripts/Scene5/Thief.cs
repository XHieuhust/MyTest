using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] Vector3 positionStartToRun;
    [SerializeField] float speedAnim;
    [SerializeField] float speedMoveWhenPlayerRun;
    private int cntDirectionMove;
    bool isMoving;
    [SerializeField] float distMove;
    [SerializeReference] float timeRandomMove;
    Vector3 newPosition;
    [SerializeField] float speedMove;
    [SerializeField] List<GameObject> ListDoChoi;

    float directY;
    private void Awake()
    {
        StartCoroutine(MoveToPositionStartToRun());
    }

    IEnumerator MoveToPositionStartToRun()
    {
        Vector2 tmpPosition;
        while (transform.position != positionStartToRun)
        {
            tmpPosition = transform.position;
            transform.position = Vector3.MoveTowards(tmpPosition, positionStartToRun, speedAnim * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        SpawnThings.ins.StartToSpawn();
        StartCoroutine(MoveWhenPlayerRun());
    }

    IEnumerator MoveWhenPlayerRun()
    {
        while (!GameScene5Manager.ins.isPlayerStartToRun)
        {
            transform.position = new Vector2(transform.position.x + speedMoveWhenPlayerRun * Time.deltaTime, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(RandomMove());
    }

    IEnumerator RandomMove()
    {
        GameScene5Manager.ins.isThiefStartToRun = true;
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
        while (true)
        {
            yield return new WaitForSeconds(timeRandomMove);
            directY = Random.Range(0, 2);
            StartCoroutine(MoveToNewPosition());
        }
    }

    IEnumerator MoveToNewPosition()
    {
        if (directY == 0 && !isMoving && cntDirectionMove > -1)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y - distMove, 0);
            cntDirectionMove -= 1;
        }

        if (directY == 1 && !isMoving && cntDirectionMove < 1)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y + distMove, 0);
            cntDirectionMove += 1;
        }

        Vector2 tmpPosition;
        while(transform.position.y != newPosition.y){
            tmpPosition = transform.position;
            transform.position = Vector2.MoveTowards(tmpPosition, newPosition, speedMove);
            yield return new WaitForEndOfFrame();
        }
    }

}
