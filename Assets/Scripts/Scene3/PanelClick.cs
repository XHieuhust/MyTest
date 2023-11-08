using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PanelClick : MonoBehaviour
{
    [SerializeField] Button trueClickBtn1;
    [SerializeField] Button trueClickBtn2;
    [SerializeField] Button falseClick;
    [SerializeField] GameObject trueTick;
    UnityAction actionBeClicked;

    private void Awake()
    {
        actionBeClicked = TrueClicked;
        trueClickBtn1.onClick.AddListener(actionBeClicked);
        trueClickBtn2.onClick.AddListener(actionBeClicked);
    }

    void TrueClicked()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Instantiate(trueTick, worldPosition, Quaternion.identity);
        StartCoroutine(StartToNextTurn());
    }

    IEnumerator StartToNextTurn()
    {
        // Cho mot chut roi tat turn hien tai -> turn tiep
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
        // Update so turn da qua
        GameScene3Manager.ins.UpdateCntCompleteTurn();
    }

}
