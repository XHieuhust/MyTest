using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toys : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector3 fallPositison;
    [SerializeField] float speedFall;
    [SerializeField] float length;
    Rigidbody2D rigidToy;
    private void Awake()
    {
        rigidToy = GetComponent<Rigidbody2D>();
        // Tam khong nam o chinh giua
        length = GetComponent<SpriteRenderer>().bounds.size.y/2;

  
        fallPositison = new Vector3(transform.position.x, transform.position.y - 2f + length, transform.position.z);
        transform.localScale = Vector2.zero;

    }

    private void Update()
    {
        if(transform.localScale.x < 0.64)
        {
            transform.position = Vector2.MoveTowards(transform.position, fallPositison, speedFall);
            transform.localScale = new Vector2(transform.localScale.x + Time.deltaTime, transform.localScale.y + Time.deltaTime);
        }else if(!GameScene5Manager.ins.isPlayerbeHitted)
        {   
            rigidToy.velocity = new Vector2(-speedMove, 0);
        }
        else
        {
            rigidToy.velocity = Vector2.zero;
        }

        if(transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameScene5Manager.ins.UpdateVpAnDuoc();
            StartCoroutine(MoveToTuiSao());
        }

        if (collision.gameObject.CompareTag("TuiSao"))
        {
            GameScene5Manager.ins.tuiSao.GetComponent<TuiSao>().UpdatePositionTuiSao();
            GameScene5Manager.ins.bar.GetComponent<BarProgress>().UpdateBar();

            Destroy(gameObject);
        }
    }

    IEnumerator MoveToTuiSao()
    {
        float speedFly = 50;
        while (gameObject)
        {
            Vector2 tmpPosition;
            while (transform.position != GameScene5Manager.ins.tuiSao.transform.position)
            {
                tmpPosition = transform.position;
                transform.position = Vector3.MoveTowards(tmpPosition, GameScene5Manager.ins.tuiSao.transform.position, speedFly * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
