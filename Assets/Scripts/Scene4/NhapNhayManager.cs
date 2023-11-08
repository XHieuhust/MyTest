using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NhapNhayManager : MonoBehaviour
{
    [SerializeField] Sprite ThanhChuNhatDam;
    [SerializeField] Sprite ThanhChuNhatThuong;
    [SerializeField] Sprite ThanhTronDam;
    [SerializeField] Sprite ThanhTronThuong;

    [SerializeField] private float timeChuyenNhapNhay;

    [SerializeField] List<GameObject> ListThanhChuNhat;
    [SerializeField] List<GameObject> ListThanhTron;


    private void Start()
    {
        StartCoroutine(StartNhapNhay());
    }

    IEnumerator StartNhapNhay()
    {
        int cnt = 0;
        int soLuongThanhChuNhat = ListThanhChuNhat.Count;
        int soLuongThanhTron = ListThanhTron.Count;
        while (true)
        {
            ListThanhChuNhat[cnt % soLuongThanhChuNhat].GetComponent<SpriteRenderer>().sprite = ThanhChuNhatDam;
            ListThanhTron[cnt % soLuongThanhTron].GetComponent<SpriteRenderer>().sprite = ThanhTronDam;
            yield return new WaitForSeconds(timeChuyenNhapNhay);
            cnt++;
            ListThanhChuNhat[(cnt-1) % soLuongThanhChuNhat].GetComponent<SpriteRenderer>().sprite = ThanhChuNhatThuong;
            ListThanhTron[(cnt - 1) % soLuongThanhTron].GetComponent<SpriteRenderer>().sprite = ThanhTronThuong;
        }

    }
}
