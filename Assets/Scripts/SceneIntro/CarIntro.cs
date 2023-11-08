using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIntro : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedRotate;
    [SerializeField] GameObject wheel1;
    [SerializeField] GameObject wheel2;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 40f)
        {
            transform.position = new Vector3(Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 2f, transform.position.y, transform.position.z);
        }
        wheel1.transform.eulerAngles -= new Vector3(0, 0, speedRotate);
        wheel2.transform.eulerAngles -= new Vector3(0, 0, speedRotate);
    }
}
