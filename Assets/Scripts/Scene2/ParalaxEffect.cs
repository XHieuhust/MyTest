using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    private float length, startpos;

    public float paralaxEffect;

    private void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x/2;
    }

    private void FixedUpdate()
    {
        float dist = Camera.main.transform.position.x * paralaxEffect;
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect > transform.position.x + length)
        {
            transform.position = new Vector3(transform.position.x + 4 * length, transform.position.y, transform.position.z);
        }
    }
}
