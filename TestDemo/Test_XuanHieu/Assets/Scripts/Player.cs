using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected bool isOnGround = true;
    Rigidbody2D rigidPlayer;
    protected float moveX;
    [SerializeField] protected float jumpSpeed;
    [SerializeField] protected float speedMove;

    private void Start()
    {
        rigidPlayer = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        moveX = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;

        transform.position += new Vector3(moveX, 0, 0) * speedMove * Time.deltaTime;
        
        if(moveX != 0)
        {
            GetComponent<SpriteRenderer>().flipX = (moveX == 1 ? false : true); 
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            isOnGround = false;
            rigidPlayer.velocity = Vector2.up * jumpSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }


}
