using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextQuestion : MonoBehaviour
{
    public GameObject textPanel;
    public Text question;

    public void TextSet()
    {
        SetQuestionText();
    }

    private void SetQuestionText()
    {
        question.text = QuestionController.Instance.question[QuestionController.Instance.actualQuestion];
    }

}
