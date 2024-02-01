using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_plus : MonoBehaviour
{
    public Text myTextObject = null;
    public int Value = 0;

    public void plus_()
    {
        if (myTextObject != null)
        {
            Value = Int32.Parse(myTextObject.text);
            myTextObject.text = Value.ToString();
        }
    }
}
