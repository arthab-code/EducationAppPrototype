using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanelController : MonoBehaviour
{
    public GameObject answerComponents;

    private TextAnswer textAnswerScript;
    private SelectAnswer selectAnswerScript;
    private PuzzleAnswer puzzleAnswerScript;


    // Start is called before the first frame update
    void Start()
    {
        AnswerController.SetCorrectlyAnswer += SetCorrectlyAnswer;

        textAnswerScript = answerComponents.GetComponent<TextAnswer>();
        selectAnswerScript = answerComponents.GetComponent<SelectAnswer>();
        puzzleAnswerScript = answerComponents.GetComponent<PuzzleAnswer>();
    }

    
    public void SetCorrectlyAnswer()
    {
        RefreshPanels();
        SetAnswerPanel();
    }

    private void RefreshPanels()
    {
        textAnswerScript.textAnswerPanel.SetActive(false);
        selectAnswerScript.SetActive(false);
        puzzleAnswerScript.SetActive(false);
    }

    private void SetAnswerPanel()
    {
        switch (QuestionController.Instance.answerType[QuestionController.Instance.actualQuestion])
        {
            case 0:
                textAnswerScript.SetDefault();
                textAnswerScript.textAnswerPanel.SetActive(true);
                break;

            case 1:
                selectAnswerScript.SetDefault();
                selectAnswerScript.SetActive(true);
                break;

            case 2:
                puzzleAnswerScript.SetDefault();
                puzzleAnswerScript.SetActive(true);
                break;
        }
    }
}
