using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueClick : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartToDestroy());
    }
    
    IEnumerator StartToDestroy()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
