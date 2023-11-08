using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThanSprite : MonoBehaviour
{
    [SerializeField] List<Sprite> ListSprite;
    [SerializeField] float speedReduceAlpha;
    IEnumerator NhapNhayThanSprite()
    {
        int cnt = 0;
        int soLuongSprite = ListSprite.Count;
        while (cnt < soLuongSprite)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            GetComponent<SpriteRenderer>().sprite = ListSprite[cnt];
            cnt++;
            if(cnt == soLuongSprite)
            {
                speedReduceAlpha = 0;
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
                GameScene4Manager.ins.EndScene();
            }
            while(GetComponent<SpriteRenderer>().color.a > 0)
            {
                GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, speedReduceAlpha * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            
        }
    }


    public void NhapNhay()
    {
        StartCoroutine(NhapNhayThanSprite());
    }


}
