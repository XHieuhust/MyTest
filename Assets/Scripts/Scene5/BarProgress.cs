using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarProgress : MonoBehaviour
{
    public void UpdateBar()
    {
        transform.localScale = new Vector2(GameScene5Manager.ins.vpAnDuoc * 1f/ GameScene5Manager.ins.completeVp, transform.localScale.y);
    }
}
