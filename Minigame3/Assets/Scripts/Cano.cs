using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rigidCano;
    Vector3 startPos;
    float eslapsed;
    [SerializeField] float timeBack;
    private void Start()
    {
        rigidCano = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        rigidCano.velocity = new Vector2(0, -speed);
        if (eslapsed > timeBack)
        {
            transform.position = startPos;
            eslapsed = 0;
        }
        eslapsed += Time.deltaTime;
    }
}
