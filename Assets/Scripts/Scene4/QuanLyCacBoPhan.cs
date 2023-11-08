using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyCacBoPhan : MonoBehaviour
{
    public static QuanLyCacBoPhan ins;
    int cntTrueBoPhan;
    [SerializeField] GameObject than;
    [SerializeField] GameObject dau;
    [SerializeField] GameObject duoi;
    private void Start()
    {
        ins = this;
    }

    public void UpdateCntTrueBoPhan()
    {
        cntTrueBoPhan++;
        if(cntTrueBoPhan == 3)
        {
            NhapNhayThan();
        }
    }

    public void NhapNhayThan()
    {
        than.GetComponent<ThanSprite>().NhapNhay();
    }

}
