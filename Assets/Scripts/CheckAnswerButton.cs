using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAnswerButton : MonoBehaviour
{ 
    public GameObject incorrectAnswerPanel;
    public GameObject questionPanel;

    public Button checkButton;

    public static bool isActive = false;

    private WaitForSeconds waitForSeconds;
    // Start is called before the first frame update
    void Start()
    {
        waitForSeconds = new WaitForSeconds(0.1f);
        AnswerController.CheckAnswerCorrectly += CheckAnswerCorrectly;

        checkButton.onClick.AddListener(delegate
        {
            CheckAnswerCorrectly();
        });

        StartCoroutine(CheckActiveButton());
    }

    private IEnumerator CheckActiveButton()
    {
        while (true)
        {
            yield return waitForSeconds;

            checkButton.gameObject.SetActive(isActive);
        }  
    }

    private void CheckAnswerCorrectly()
    {

        if (AnswerController.Instance.isCorrectAnswer == false)
        {
            incorrectAnswerPanel.SetActive(true);
            return;
        }

        if (QuestionController.Instance.actualQuestion == QuestionController.Instance.actualMaxQuestions - 1)
        {
            if (AnswerController.Instance.isCorrectAnswer == true)
            {
                QuestionController.Instance.actualQuestion = 0;
                questionPanel.SetActive(false);
            }

            return;
        }

        AnswerController.Instance.isCorrectAnswer = false;
        CheckAnswerButton.SetActiveCheckButton(false);
        QuestionController.Instance.actualQuestion += 1;
        QuestionController.Instance.SetQuestion();
        AnswerController.Instance.SetAnswer();
    }

    public static void SetActiveCheckButton(bool value)
    {
        isActive = value;
    }
}
