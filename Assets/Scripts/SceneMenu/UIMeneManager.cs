using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMeneManager : MonoBehaviour
{
    [SerializeField] Button button1;

    private void Awake()
    {
        button1.onClick.AddListener(delegate
        {
            ScenesManager.ins.LoadScene("Scene1");
        }); 
    }
}
