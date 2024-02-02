using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Test_plus : MonoBehaviour
{
    public TextMeshProUGUI myTextObject = null;
    public int Value = 0;

    public void plus_()
    {
        if (myTextObject != null)
        {
            int.TryParse(myTextObject.text, out Value);
            Value++;
            myTextObject.text = Value.ToString();
        }
    }
}
