using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndPosition : MonoBehaviour
{
    [SerializeField] GameObject car;

    private void Update()
    {
        CheckEndGame();
    }

    void CheckEndGame()
    {
        if(car.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            StartCoroutine(StartToLoadNextScene());
        }
    }

    IEnumerator StartToLoadNextScene()
    {
        yield return new WaitForSeconds(1);
        ScenesManager.ins.LoadScene("Scene3");
    }
}
