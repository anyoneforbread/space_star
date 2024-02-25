using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject planetPopupUI;
    [SerializeField] private GameObject UIManager;

    private void OnMouseDown()
    {
        planetPopupUI.SetActive(false);
        UIManager.GetComponent<UIManager>().DelayedEnable(0.2f);
        Debug.Log("closed");
    }
}
