using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleArray : Singleton<PuzzleArray>
{
    public Image[] puzzles;
    public Text[] puzzleTexts;
    public PuzzleScript[] puzzleScripts;

    private void Start()
    {
        SetPuzleScriptArray();
        SetTextArray();
    }
    public void SetTextArray()
    {
        puzzleTexts = new Text[puzzles.Length];

        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzleTexts[i] = puzzles[i].GetComponentInChildren<Text>();
        }
    
    }

    private void SetPuzleScriptArray()
    {
        puzzleScripts = new PuzzleScript[puzzles.Length];

        for (int i = 0; i < puzzles.Length; i++)
        {
            puzzleScripts[i] = puzzles[i].GetComponent<PuzzleScript>();
        }
    }
}
