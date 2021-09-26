using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : Singleton<AnswerController>
{
    public bool isCorrectAnswer;

    public delegate void AnswerCallback();

    public static event AnswerCallback SetCorrectlyAnswer;
    public static event AnswerCallback CheckAnswerCorrectly;

    public void SetAnswer()
    {
        SetCorrectlyAnswer();
    }


}
