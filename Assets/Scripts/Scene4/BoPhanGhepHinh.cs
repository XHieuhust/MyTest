using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoPhanGhepHinh : DragSprite
{
    [SerializeField] GameObject hinhVuongHienThi;

    private void Start()
    {
        SetStartValue();
    }
    public override void CorrectDrag()
    {
        base.CorrectDrag();
        Destroy(hinhVuongHienThi);
        QuanLyCacBoPhan.ins.UpdateCntTrueBoPhan();
    }

    public override void ChangeScale()
    {
        // Chi co 1 true object
        transform.localScale = ListTrueObjects[0].transform.localScale;
    }

    void SetStartValue()
    {
        startPos = transform.position;
        scaleNormal = transform.localScale;
    }

}
