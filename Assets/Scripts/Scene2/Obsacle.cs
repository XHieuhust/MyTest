using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obsacle : MonoBehaviour
{
    protected Rigidbody2D rigidObsacle;
    [SerializeField] protected float ForceFly;
    void Awake()
    {
        rigidObsacle = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            beHitted();
        }
    }

    public abstract void beHitted();

    private void Update()
    {
        if(rigidObsacle.velocity.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
