using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrangPhucCanhSat : DragSprite
{
    GameObject dayTrangPhuc;
    public void Start()
    {
        scaleNormal = transform.localScale;
    }
    public override void CorrectDrag()
    {
        base.CorrectDrag();
        QuanLyPolice.ins.AddPoliceDaMacDo(firstTrueObject);
        if (dayTrangPhuc)
        {
            // Do get true xay ra sau khi quan ly trang phuc sinh
            dayTrangPhuc.GetComponent<QuanLyTrangPhuc>().isTrueTrangPhuc = true;
            dayTrangPhuc = null;
        }

    }

    public override void ChangeScale()
    {
        transform.localScale = new Vector2(scaleNormal.x * 1.2f, scaleNormal.x * 1.2f);
    }

    public void SetStartValue(Vector3 newStartPos)
    {
        startPos = transform.position;
        startPos.Set(newStartPos.x, newStartPos.y, newStartPos.z);
    }

    public override void DoSthingWhenOnMouseDown()
    {
        base.DoSthingWhenOnMouseDown();
        if (transform.parent)
        {
            dayTrangPhuc = transform.parent.gameObject;
            transform.parent = null;
        }
        if (dayTrangPhuc)
            dayTrangPhuc.GetComponent<QuanLyTrangPhuc>().StartToMoveToHoldPosition();
    }

    public override void DoSthingWhenOnMouseUp()
    {
        base.DoSthingWhenOnMouseUp();
        if (dayTrangPhuc)
            dayTrangPhuc.GetComponent<QuanLyTrangPhuc>().StartToMoveToStartPosition();
    }
}
