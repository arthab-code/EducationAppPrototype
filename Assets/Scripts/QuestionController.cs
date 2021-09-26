using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : Singleton<QuestionController>
{
    public int actualQuestion = 0;
    public int actualMaxQuestions;
    public int answerQuantity;

    public int[] questionType; // załadowuje odpowiedni panel
    public int[] answerType;   // załadowuje odpowiedni system odpowiedzi
    public string[] videoPath;  
    public string[] audioPath;
    public string[] imagePath;
    public string[] question;
    public List<string>[] answer;
    public List<short>[] answerCorrect;

    public delegate void SetQuestionCallback();

    public static event SetQuestionCallback SetAnswerData;
    public static event SetQuestionCallback CheckTextAnswer;
    public static event SetQuestionCallback SaveSelectAnswer;
    public static event SetQuestionCallback SetCorrectlyQuestion;

    public void SetQuestion()
    {
        SetCorrectlyQuestion();
    }

    public void SetCorrectlyAnswer()
    {
        SaveSelectAnswer();
    }
    public void CheckTextAnswerCorrectly()
    {
        CheckTextAnswer();
    }
   
    public int GetAnswerQuantity()
    {
        return answerQuantity = answer[actualQuestion].Count;
    }
}
