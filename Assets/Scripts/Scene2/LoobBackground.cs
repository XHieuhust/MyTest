using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoobBackground : MonoBehaviour
{
    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;
    [SerializeField] float speedLayer;
    float oldPosition;
    private void FixedUpdate()
    {
        LayerTransform();
        LoopLayer();
    }

    void LayerTransform()
    {
        if(Camera.main.transform.position.x > 0 && (Camera.main.transform.position.x != oldPosition))
        {
            //bg1.transform.position += new Vector3(speedLayer * car.GetComponent<Rigidbody2D>().velocity.x / 10, 0, 0);
            //bg2.transform.position += new Vector3(speedLayer * car.GetComponent<Rigidbody2D>().velocity.x / 10, 0, 0);
         
            float dist = (Camera.main.transform.position.x - oldPosition) * speedLayer;
            bg1.transform.position += new Vector3(dist, 0, 0);
            bg2.transform.position += new Vector3(dist, 0, 0);
            oldPosition = Camera.main.transform.position.x;
        }
    }

    void LoopLayer()
    {
        if (bg1.transform.position.x + bg1.GetComponent<SpriteRenderer>().size.x / 2 <= Camera.main.transform.position.x - Camera.main.aspect * Camera.main.orthographicSize)
        {
            bg1.transform.position = new Vector3(bg2.transform.position.x + bg2.GetComponent<SpriteRenderer>().size.x / 2 + bg1.GetComponent<SpriteRenderer>().size.x / 2 - 0.05f, bg1.transform.position.y, 0);
        }

        if (bg2.transform.position.x + bg2.GetComponent<SpriteRenderer>().size.x / 2 <= Camera.main.transform.position.x - Camera.main.aspect * Camera.main.orthographicSize)
        {
            bg2.transform.position = new Vector3(bg1.transform.position.x + bg1.GetComponent<SpriteRenderer>().size.x / 2 + bg2.GetComponent<SpriteRenderer>().size.x / 2 - 0.05f, bg1.transform.position.y, 0);
        }
    }
}
