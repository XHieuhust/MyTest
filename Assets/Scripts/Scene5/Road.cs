using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Rigidbody2D rigidBg;

    private void Awake()
    {
        rigidBg = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!GameScene5Manager.ins.isPlayerbeHitted && GameScene5Manager.ins.isPlayerStartToRun) {
            rigidBg.velocity = new Vector2(-speedMove, 0);
        }
        else
        {
            rigidBg.velocity = Vector2.zero;
        }
        if (transform.position.x + GetComponent<SpriteRenderer>().size.x / 2 <= Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect )
        {
            transform.position = new Vector2(transform.position.x + 4 * GetComponent<SpriteRenderer>().size.x / 2 - 0.02f, transform.position.y);
        }
    }
}
