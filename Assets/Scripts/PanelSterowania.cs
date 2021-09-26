using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSterowania : MonoBehaviour
{
    public static string wytyczneTxt;
    public static string kategoriaTxt;
    public static bool correctAnswer;

    public GameObject startPanel;
    public GameObject wybierzWytycznePanel;
    public GameObject wybierzKategoriePanel;
    public GameObject wlasciwyPanel;
    public GameObject answerIncorrectPanel;
    public GameObject questionPanel;

    public Button dalej;
    public Button aha;
    public Button erc;
    public Button child;
    public Button adult;
    public Button powtorz;
    public Button sprawdzOdpowiedz;
    public Button lekcja1;
    public Button accept;

    public Text wytyczne;
    public Text kategoria;
    // Start is called before the first frame update
    void Start()
    {
        dalej.onClick.AddListener(delegate
        {
            startPanel.SetActive(false);
            wybierzWytycznePanel.SetActive(true);
        });

        aha.onClick.AddListener(delegate
        {
            wybierzKategoriePanel.SetActive(true);
            wybierzWytycznePanel.SetActive(false);
            wytyczne.text = "First";
        });

        erc.onClick.AddListener(delegate
        {
            wybierzKategoriePanel.SetActive(true);
            wybierzWytycznePanel.SetActive(false);
            wytyczne.text = "Second";
        });

        child.onClick.AddListener(delegate
        {
            wybierzKategoriePanel.SetActive(false);
            wlasciwyPanel.SetActive(true);
            kategoria.text = "One";
        });

        adult.onClick.AddListener(delegate
        {
            wybierzKategoriePanel.SetActive(false);
            wlasciwyPanel.SetActive(true);
            kategoria.text = "Two";
        });

        powtorz.onClick.AddListener(delegate
        {
            answerIncorrectPanel.SetActive(false);
        });

        sprawdzOdpowiedz.onClick.AddListener(delegate
        {
            CheckAnswer();
        });

        lekcja1.onClick.AddListener(delegate
        {
            questionPanel.SetActive(true);
            FileManager.Instance.LoadAllDataFromFile("pl", "1", "1", "1");
            QuestionController.Instance.SetQuestion();
            AnswerController.Instance.SetAnswer();
        });

    }

    private void CheckAnswer()
    {
        if (correctAnswer == true)
            questionPanel.SetActive(false);
        else
            answerIncorrectPanel.SetActive(true);
    }
}
