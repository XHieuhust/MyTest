using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sao : MonoBehaviour
{
    [SerializeField] Sprite UpdateSprite;
    bool isUpdated;
    Vector2 nomarlScale;

    private void Start()
    {
        nomarlScale = transform.localScale;    
    }

    private void Update()
    {
        if(GameScene5Manager.ins.tuiSao.transform.position.x >= transform.position.x && !isUpdated)
        {
            GetComponent<SpriteRenderer>().sprite = UpdateSprite;
            isUpdated = true;
            StartCoroutine(NhapNhay());
        }
    }

    IEnumerator NhapNhay()
    {
        transform.localScale = new Vector2(1.1f * nomarlScale.x, 1.1f * nomarlScale.y);
        yield return new WaitForEndOfFrame();
        transform.localScale = nomarlScale;
    }
}
