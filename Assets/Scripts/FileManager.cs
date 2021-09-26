using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManager : Singleton<FileManager>
{
    public PathData pathData;

    private void Start()
    {
        pathData = new PathData();
    }

    public void LoadAllDataFromFile(string language, string category, string lesson, string module)
    {
        GlobalSettings.Instance.category = category;
        GlobalSettings.Instance.lesson = lesson;
        GlobalSettings.Instance.module = module;

        pathData.SetFileName(language, category, lesson, module);
        pathData.SetFilePath(language, category, lesson, module);
        LoadData();
    }

    private void LoadData()
    {
        TextAsset loadFileData = Resources.Load<TextAsset>(pathData.GetFilePath() + pathData.GetFileName());
        string textContent = loadFileData.text;
        string[] prepareTextData = textContent.Split('\n');
        
        int linesNumber = prepareTextData.Length;
        int questionCounter = 0;


        CountQuestions(prepareTextData, linesNumber, ref questionCounter);

        CreateQuestionControllerDataBoards(questionCounter);

        LoadDataToBoards(prepareTextData, linesNumber);
    }

    private void CountQuestions(string[] textData, int linesNumber, ref int questionCounter)
    {
        for (int i = 0; i < linesNumber; i++)
        {
            if ((textData[i])[0] == '>')
            {
                questionCounter++;
            }
        }

        QuestionController.Instance.actualMaxQuestions = questionCounter;
    }

    private void LoadDataToBoards(string[] textData, int linesNumber)
    {
        int dataSelector = 0;                    // Odpowiada za wybór tablicy do której zapisywana jest dana linia z pliku
        bool isCountingQuestions = false;
        int actualQuestionData = -1;

        for (int i = 0; i < linesNumber; i++)
        {
            if ((textData[i])[0] == '>')
            {
                actualQuestionData++;
                continue;
            }
            if ((textData[i])[0] == '-')
            {
                isCountingQuestions = true;
                continue;
            }

            if ((textData[i])[0] == '<')
            {
                isCountingQuestions = false;
                dataSelector = 0;
                continue;
            }

            if (isCountingQuestions == true)       // Pobieranie danych do List ANSWER i AnswerCorrect z pliku
            {
                string[] answerTemp = textData[i].Split('_');
                QuestionController.Instance.answer[actualQuestionData].Add(answerTemp[0]);
                QuestionController.Instance.answerCorrect[actualQuestionData].Add(Int16.Parse(answerTemp[1]));
            }
            else                                   // Pobieranie danych z pliku
            {
                switch (dataSelector)
                {
                    case 0:
                        QuestionController.Instance.questionType[actualQuestionData] = Int32.Parse(textData[i]);
                        break;

                    case 1:
                        QuestionController.Instance.answerType[actualQuestionData] = Int32.Parse(textData[i]);
                        break;

                    case 2:
                        QuestionController.Instance.videoPath[actualQuestionData] = textData[i];
                        break;

                    case 3:
                        QuestionController.Instance.audioPath[actualQuestionData] = textData[i];
                        break;

                    case 4:
                        QuestionController.Instance.imagePath[actualQuestionData] = textData[i];
                        break;

                    case 5:
                        QuestionController.Instance.question[actualQuestionData] = textData[i];
                        break;
                }
            }

            if (dataSelector < 6) dataSelector++;
        }
    }

    private void CreateQuestionControllerDataBoards(int boardSize)
    {
        QuestionController.Instance.questionType = new int[boardSize];
        QuestionController.Instance.answerType = new int[boardSize];
        QuestionController.Instance.videoPath = new string[boardSize];
        QuestionController.Instance.audioPath = new string[boardSize];
        QuestionController.Instance.imagePath = new string[boardSize];
        QuestionController.Instance.question = new string[boardSize];
        QuestionController.Instance.answer = new List<string>[boardSize];
        QuestionController.Instance.answerCorrect = new List<short>[boardSize];

        for (int i = 0; i < boardSize; i++)
        {
            QuestionController.Instance.answer[i] = new List<string>();
            QuestionController.Instance.answerCorrect[i] = new List<short>();
        }
    }
}
