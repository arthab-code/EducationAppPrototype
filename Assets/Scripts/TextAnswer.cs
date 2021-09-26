using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextAnswer : MonoBehaviour
{
    public InputField answerField;
    public GameObject textAnswerPanel;

    private void Start()
    {
        answerField.onValueChanged.AddListener(delegate
        {
            CheckAnswerCorrectness();
        });

    }

    public void SetDefault()
    {
        answerField.text = "";
    }

    private void CheckAnswerCorrectness()
    {
        CheckAnswerButton.SetActiveCheckButton(true);

        string answerTemp = QuestionController.Instance.answer[QuestionController.Instance.actualQuestion][0];

        if (answerField.text.Length < answerTemp.Length || answerField.text.Length > answerTemp.Length)
        {
            AnswerController.Instance.isCorrectAnswer = false;
            return;
        } 

        for (int i=0; i< answerTemp.Length; i++)
        {
            if (Char.ToUpper(answerField.text[i]) == Char.ToUpper(answerTemp[i]))
            {
                AnswerController.Instance.isCorrectAnswer = true;
            }
            else
            {
                AnswerController.Instance.isCorrectAnswer = false;
                
                break;
            }
        }
    }
   
}
