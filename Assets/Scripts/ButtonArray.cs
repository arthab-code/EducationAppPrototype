using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArray : Singleton<ButtonArray>
{
    public Button[] buttons;
    public Text[] buttonTexts;
   // public Vector3[] startPosition;
    private void Start()
    {
        SetTextArray();
    }
    private void SetTextArray()
    {
        buttonTexts = new Text[buttons.Length];

        for (int i = 0; i < buttons.Length; i++)
            buttonTexts[i] = buttons[i].GetComponentInChildren<Text>();
    }

}
