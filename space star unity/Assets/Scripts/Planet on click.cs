using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlanetOnClick : MonoBehaviour
{

    private GameObject canvas;
    private GameObject planetPopupUI;
    private GameObject planetPopupUITitle;
    private GameObject planetPopupUIDescription;
    private GameObject planetPopupUIImage;
    private GameObject UIManager;

    [SerializeField] private Sprite sprite;
    [TextArea(2, 4)][SerializeField] private string title="";
    [TextArea(15, 20)] [SerializeField] private string description="";
    private TextMeshProUGUI UITitle;
    private TextMeshProUGUI UIDescription;
    private Image UIImage;


    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("UI");
        UIManager = canvas.transform.GetChild(0).gameObject;
        planetPopupUI = canvas.transform.GetChild(6).gameObject;  //need planet info to be 7th child

        planetPopupUITitle = planetPopupUI.transform.GetChild(2).gameObject;
        planetPopupUIDescription = planetPopupUI.transform.GetChild(3).gameObject;
        planetPopupUIImage = planetPopupUI.transform.GetChild(4).gameObject;

        planetPopupUI.SetActive(false);

        
    }

    private void OnMouseDown()
    {
        UITitle = planetPopupUITitle.GetComponent<TextMeshProUGUI>();
        UITitle.text = title;

        UIDescription = planetPopupUIDescription.GetComponent<TextMeshProUGUI>();
        UIDescription.text = description;

        UIImage = planetPopupUIImage.GetComponent<Image>();
        UIImage.sprite = sprite;

        planetPopupUI.SetActive(true);
        UIManager.GetComponent<UIManager>().DisableButtons();
        Debug.Log("clicked");
    }



}
