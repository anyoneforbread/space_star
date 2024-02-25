using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    [SerializeField] private GameObject planetPopupUI;

    private void OnMouseDown()
    {
        
        planetPopupUI.SetActive(false);
        Debug.Log("closed");
    }
}
