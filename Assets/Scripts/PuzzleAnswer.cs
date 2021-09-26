using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleAnswer : MonoBehaviour
{
    public GameObject puzzleAnswerPanel;
    public GameObject puzzleArray;

    private int puzzlesQuantity;
    private int tempIndex;
    private bool isSearched = false;
    private short[] tempAnswersValue;

    private void Update()
    {
        if (PuzzleScript.globalDragCallback)
        {
            if (isSearched == false)
            {
                SearchDragPuzzle();
            }
            else
            {
                ChangePuzzlesPosition();
            }
        }
    }

    public void SetDefault()
    {
        ResetPuzzles();
        ShowPuzzles();
    }

    public void SetActive(bool value)
    {
        puzzleAnswerPanel.SetActive(value);
        puzzleArray.SetActive(value);
    }

    private void SearchDragPuzzle()
    {
        for (int i = 0; i < puzzlesQuantity; i++)
        {
            if (PuzzleArray.Instance.puzzles[i].GetComponent<PuzzleScript>().isDraged == true)
            {
                isSearched = true;
                tempIndex = i;
            }
        }
    }

    private void ChangePuzzlesPosition()
    {
        if (tempIndex > 0 && tempIndex < QuestionController.Instance.answer[QuestionController.Instance.actualQuestion].Count-1)
        {

            if (PuzzleArray.Instance.puzzles[tempIndex].transform.position.y > PuzzleArray.Instance.puzzles[tempIndex - 1].transform.position.y - 0.2f &&
                PuzzleArray.Instance.puzzles[tempIndex].transform.position.y < PuzzleArray.Instance.puzzles[tempIndex - 1].transform.position.y + 0.2f)
            {
                SwapElementPlace(-1); // do góry wertuje elementy tablicy
            }

            if (PuzzleArray.Instance.puzzles[tempIndex].transform.position.y > PuzzleArray.Instance.puzzles[tempIndex + 1].transform.position.y - 0.2f &&
               PuzzleArray.Instance.puzzles[tempIndex].transform.position.y < PuzzleArray.Instance.puzzles[tempIndex + 1].transform.position.y + 0.2f)
            {
                SwapElementPlace(1); // do dołu wertuje elementy tablicy
            }
        }

        if (tempIndex == 0)
        {
            if (PuzzleArray.Instance.puzzles[tempIndex].transform.position.y > PuzzleArray.Instance.puzzles[tempIndex + 1].transform.position.y - 0.2f &&
                PuzzleArray.Instance.puzzles[tempIndex].transform.position.y < PuzzleArray.Instance.puzzles[tempIndex + 1].transform.position.y + 0.2f)
            {
                SwapElementPlace(1); // do dołu wertuje elementy tablicy
            }
        }

        if (tempIndex == puzzlesQuantity-1)
        {
            if (PuzzleArray.Instance.puzzles[tempIndex].transform.position.y > PuzzleArray.Instance.puzzles[tempIndex - 1].transform.position.y - 0.2f &&
            PuzzleArray.Instance.puzzles[tempIndex].transform.position.y < PuzzleArray.Instance.puzzles[tempIndex - 1].transform.position.y + 0.2f)
            {
                SwapElementPlace(-1); // do góry wertuje elementy tablicy
            }
        }
        PuzzleArray.Instance.SetTextArray(); //ODSWIEŻA NAPISY ABY BYLY W POPRAWNYM MIEJSCU PO PRZENIESIENIU PUZLI
        isSearched = false;
    }

    private void SwapElementPlace(int index)
    {
        Image tempPuzzle = PuzzleArray.Instance.puzzles[tempIndex + index];
        PuzzleScript tempPuzzleScript = PuzzleArray.Instance.puzzleScripts[tempIndex + index];
        Vector3 tmpStartPosition = PuzzleArray.Instance.puzzleScripts[tempIndex].startPosition;
        Vector3 tmpNewPosition = PuzzleArray.Instance.puzzleScripts[tempIndex + index].startPosition;
        short tempCorrectAnswer = tempAnswersValue[tempIndex + index];

        PuzzleArray.Instance.puzzles[tempIndex + index] = PuzzleArray.Instance.puzzles[tempIndex];
        PuzzleArray.Instance.puzzles[tempIndex] = tempPuzzle;
        PuzzleArray.Instance.puzzleScripts[tempIndex + index] = PuzzleArray.Instance.puzzleScripts[tempIndex];
        PuzzleArray.Instance.puzzleScripts[tempIndex] = tempPuzzleScript;
        tempAnswersValue[tempIndex + index] = tempAnswersValue[tempIndex];
        tempAnswersValue[tempIndex] = tempCorrectAnswer;

        PuzzleArray.Instance.puzzleScripts[tempIndex + index].newPosition = tmpNewPosition;
        PuzzleArray.Instance.puzzleScripts[tempIndex + index].startPosition = tmpNewPosition;
        PuzzleArray.Instance.puzzleScripts[tempIndex].transform.position = tmpStartPosition;
        PuzzleArray.Instance.puzzleScripts[tempIndex].startPosition = tmpStartPosition;

        CheckCorrectlyAnswer();
    }

    private void CheckCorrectlyAnswer()
    {
        int countCorrectAnswers = 0;

        for (int i=0; i<puzzlesQuantity; i++)
        {
            if ((i + 1) == tempAnswersValue[i])
                countCorrectAnswers++;
        }

        if (countCorrectAnswers == puzzlesQuantity)
            AnswerController.Instance.isCorrectAnswer = true;
        else
            AnswerController.Instance.isCorrectAnswer = false;
    }    

    private void ResetPuzzles()
    {
        for (int i=0; i< PuzzleArray.Instance.puzzles.Length; i++)
        {
            PuzzleArray.Instance.puzzles[i].gameObject.SetActive(false);
        }
    }
    private void SetTempAnswers()
    {
        tempAnswersValue = new short[QuestionController.Instance.answerCorrect[QuestionController.Instance.actualQuestion].Count];
        for (int i = 0; i < QuestionController.Instance.answerCorrect[QuestionController.Instance.actualQuestion].Count; i++)
        {
            tempAnswersValue[i] = QuestionController.Instance.answerCorrect[QuestionController.Instance.actualQuestion][i];
        }
    }
    private void ShowPuzzles()
    {
        puzzleArray.SetActive(true);
        puzzlesQuantity = QuestionController.Instance.answer[QuestionController.Instance.actualQuestion].Count;
        CheckAnswerButton.SetActiveCheckButton(true);

        for (int i = 0; i < puzzlesQuantity; i++)
        {
            PuzzleArray.Instance.puzzles[i].gameObject.SetActive(true);
            PuzzleArray.Instance.puzzleTexts[i].text = QuestionController.Instance.answer[QuestionController.Instance.actualQuestion][i];
        }

        SetTempAnswers();   //USTAWIA WARTOSCI TABELI POMOCNICZEJ Z ODPOWIEDZIAMI
        CheckCorrectlyAnswer();   // SPRAWDZA POPRAWNOSC ULOZENIA ODPOWIEDZI< GDYZ MOGA ONE BYC OD SAMEGO POCZATKU POPRAWNIE ULOZONE
    }
}
