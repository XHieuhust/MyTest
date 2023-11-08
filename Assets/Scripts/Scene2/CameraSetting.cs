using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] Transform endPosition;
    // Update is called once per frame
    void Update()
    {
        // Camera in car
        if (car.transform.position.x >= 0 && car.transform.position.x <= endPosition.position.x) 
            this.transform.position = new Vector3(car.transform.position.x, transform.position.y, transform.position.z);
    }

}
