using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheckbox : MonoBehaviour
{
    private Button[] buttons;
    public int checkboxValue;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();

        buttons[0].onClick.AddListener(delegate
        {
            buttons[1].image.color = UnityEngine.Color.white;
            buttons[0].image.color = UnityEngine.Color.blue;
            checkboxValue = 1;
            PanelSterowania.correctAnswer = true;
            Debug.Log("Wartosc checkbox : "+checkboxValue);
        });

        buttons[1].onClick.AddListener(delegate
        {
            buttons[0].image.color = UnityEngine.Color.white;
            buttons[1].image.color = UnityEngine.Color.blue;
            checkboxValue = 2;
            PanelSterowania.correctAnswer = false;
            Debug.Log("Wartosc checkbox : " + checkboxValue);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
