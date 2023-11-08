using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyTrangPhuc : MonoBehaviour
{
    [SerializeField] List<GameObject> ListTrangPhucs;
    [SerializeField] bool flipX;
    public Vector3 startPos;
    Vector3 beHoldPosition;
    GameObject trangPhucTmp;
    public bool isTrueTrangPhuc;

    private void Awake()
    {
        startPos = transform.position;
        beHoldPosition = new Vector3(transform.position.x, transform.position.y + Camera.main.orthographicSize, transform.position.z);
        transform.position = beHoldPosition;
    }
    public void InstantiateTrangPhuc(int cnt)
    {
        StartToMoveToStartPosition();
        trangPhucTmp = Instantiate(ListTrangPhucs[cnt], transform.position, Quaternion.identity);
        trangPhucTmp.GetComponent<SpriteRenderer>().flipX = flipX;
        trangPhucTmp.transform.SetParent(gameObject.transform, true);
        trangPhucTmp.GetComponent<TrangPhucCanhSat>().SetStartValue(startPos);
    }

    IEnumerator MoveToStartPosition()
    {
        if (!isTrueTrangPhuc)
        {
            float elapsedTime = 0;
            float seconds = 0.25f;
            Vector3 startingPos = transform.position;
            while (elapsedTime < seconds)
            {
                transform.position = Vector3.Lerp(startingPos, startPos, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            transform.position = startPos;
        }
        isTrueTrangPhuc = false;
    }

    public void StartToMoveToHoldPosition()
    {
        StartCoroutine(MoveToHoldPosition());
    }
    
    public void StartToMoveToStartPosition()
    {
        StartCoroutine(MoveToStartPosition());
    }

    IEnumerator MoveToHoldPosition()
    {
        float elapsedTime = 0;
        float seconds = 0.25f;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, beHoldPosition, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = beHoldPosition;
    }


}
