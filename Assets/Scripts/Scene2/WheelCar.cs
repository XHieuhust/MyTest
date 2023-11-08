using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCar : MonoBehaviour
{
    [SerializeField] public float speedRotate;
    [SerializeField] GameObject car;

    void Update()
    {
        RotateWheel();
    }   

    private void RotateWheel()
    {   
        if(car.GetComponent<Rigidbody2D>().velocity.x != 0)
            transform.eulerAngles -= new Vector3(0, 0, speedRotate);
    }

}
