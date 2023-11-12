using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    bool isCanMove;
    bool isOnCar;
    Button button;
    public int indexRow;
    public int indexCol;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Map.ins.car.Move(indexRow, indexCol, transform.position);
    }
}
