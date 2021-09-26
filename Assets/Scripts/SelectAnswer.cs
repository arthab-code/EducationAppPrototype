using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnswer : MonoBehaviour
{
    public GameObject selectAnswerPanel;

    public GameObject buttonArray;

    private int buttonsQuantity;

    private void Start()
    {
        SetButtonDelegate();
    }

    private void SetButtonDelegate()
    {
        for (int i = 0; i < ButtonArray.Instance.buttons.Length; i++)
        {
            AddListener(i);
        }
    }

    private void AddListener(int index)
    {
        ButtonArray.Instance.buttons[index].onClick.AddListener(delegate
        {
            ResetButtonsClicked();
            SetButtonClicked(index);
            CheckAnswerCorrectly(index);
        });
    }

    private void ResetButtonsClicked()
    {
        for (int i = 0; i < ButtonArray.Instance.buttons.Length; i++)
        {
            ButtonArray.Instance.buttons[i].image.color = UnityEngine.Color.white;
        }
    }

    private void SetButtonClicked(int index)
    {
        ButtonArray.Instance.buttons[index].image.color = UnityEngine.Color.green;
        CheckAnswerButton.SetActiveCheckButton(true);
    }

    public void SetDefault()
    {
        ResetShowButtons();
        ResetButtonsClicked();
        ShowButtons();
    }
    private void ResetShowButtons()
    {
        for (int i=0; i< ButtonArray.Instance.buttons.Length;i++)
            ButtonArray.Instance.buttons[i].gameObject.SetActive(false);
    }

    private void CheckAnswerCorrectly(int index)
    {
        if (QuestionController.Instance.answerCorrect[QuestionController.Instance.actualQuestion][index] == 1)
        {
            AnswerController.Instance.isCorrectAnswer = true;
        }
        else
        {
            AnswerController.Instance.isCorrectAnswer = false;
        }
    }

    private void ShowButtons()
    {
        buttonArray.SetActive(true);
        ResetButtonsClicked();
        buttonsQuantity = QuestionController.Instance.answer[QuestionController.Instance.actualQuestion].Count;

        for (int i = 0; i < buttonsQuantity; i++)
        {
            ButtonArray.Instance.buttons[i].gameObject.SetActive(true);
            ButtonArray.Instance.buttonTexts[i].text = QuestionController.Instance.answer[QuestionController.Instance.actualQuestion][i]; 
        }
    }
        
    public void SetActive(bool value)
    {
        buttonArray.SetActive(value);
        selectAnswerPanel.SetActive(value);
    }
}
