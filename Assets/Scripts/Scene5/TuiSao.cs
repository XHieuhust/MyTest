using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuiSao : MonoBehaviour
{
    [SerializeField] GameObject SaoTo;
    float lengthThanh;
    Vector2 nomarlScale;
    private void Start()
    {
        nomarlScale = transform.localScale;
        lengthThanh = SaoTo.transform.position.x - transform.position.x;
    }
    public void UpdatePositionTuiSao()
    {
        transform.position += new Vector3(lengthThanh / GameScene5Manager.ins.completeVp, 0, 0);
        StartCoroutine(NhapNhay());
    }

    IEnumerator NhapNhay()
    {
        transform.localScale = new Vector2(1.2f * nomarlScale.x, 1.2f * nomarlScale.y);
        yield return new WaitForSeconds(0.2f);
        transform.localScale = nomarlScale;
    }
}
