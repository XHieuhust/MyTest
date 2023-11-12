using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bridge : MonoBehaviour
{
    [SerializeField] Sprite OpenSprite;
    [SerializeField] Sprite CloseSprite;

    Image spriteBridge;
    private void Start()
    {
        spriteBridge = GetComponent<Image>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteBridge.sprite = OpenSprite;
        Map.ins.SetFalseCellBridge();
        int curRow = Map.ins.cellOnCar.indexRow;
        int curCol = Map.ins.cellOnCar.indexCol;

        if (curRow == 2)
        {
            if (curCol == 5 || curCol == 6 || curCol == 7 || curCol == 8)
            {
                Map.ins.car.MoveBackBridge();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteBridge.sprite = CloseSprite;
        Map.ins.SetTrueCellBridge();
    }
}
