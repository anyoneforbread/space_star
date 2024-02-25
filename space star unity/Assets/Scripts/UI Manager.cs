using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject planetInfoPopup;
    [SerializeField] private List<GameObject> moveButtonParents;

    public void DelayedEnable(float t)
    {
        Invoke("EnableButtons", t);
    }

    public void DisableButtons()
    {
        foreach (GameObject buttonParent in moveButtonParents)
        {
            Button moveButton = buttonParent.GetComponent<Button>();
            moveButton.interactable = false;
        }
    }

    public void EnableButtons()
    {
        foreach (GameObject buttonParent in moveButtonParents)
        {
            Button moveButton = buttonParent.GetComponent<Button>();
            moveButton.interactable = true;
        }
    }
}
