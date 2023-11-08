using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 positionStartToRun;
    [SerializeField] float speedAnim;
    private int cntDirectionMove;
    [SerializeField] float distMove;
    bool isMoving;
    Vector3 newPosition;
    [SerializeField] float speedMove;

    private void Awake()
    {
        StartCoroutine(MoveToPositionStartToRun());
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }
    // Update is called once per frame
    void Update()
    {
        CheckIsMoving();
        if(GameScene5Manager.ins.isPlayerStartToRun) Move();
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
        GameScene5Manager.ins.isPlayerStartToRun = true;
        newPosition = new Vector3(transform.position.x, transform.position.y, 0);
    }

    float startMouse;
    float endMouse;
    float timeDelay;
    void Move()
    {
        timeDelay += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeDelay > 0.5f && !GameScene5Manager.ins.isPlayerbeHitted)
        {
            endMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float directY = (startMouse != 0 ? endMouse - startMouse : 0);
            startMouse = endMouse;
            if ((directY < 0) && !isMoving && cntDirectionMove > -1)
            {
                newPosition = new Vector3(newPosition.x, newPosition.y - distMove, 0);
                cntDirectionMove -= 1;
            }

            if ((directY > 0) && !isMoving && cntDirectionMove < 1)
            {
                newPosition = new Vector3(newPosition.x, newPosition.y + distMove, 0);
                cntDirectionMove += 1;
            }
            if (isMoving) timeDelay = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            startMouse = endMouse = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, newPosition, speedMove);
    }
    void CheckIsMoving()
    {
        if (transform.position == newPosition)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }


}
