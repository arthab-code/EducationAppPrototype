using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanelController : MonoBehaviour
{
    public GameObject questionComponents;

    private VideoQuestion videoQuestionScript;
    private ImageQuestion imageQuestionScript;
    private TextQuestion textQuestionScript;

    private void Start()
    {
        QuestionController.SetCorrectlyQuestion += SetCorrectlyQuestion;

        videoQuestionScript = questionComponents.GetComponent<VideoQuestion>();
        imageQuestionScript = questionComponents.GetComponent<ImageQuestion>();
        textQuestionScript = questionComponents.GetComponent<TextQuestion>();
    }

    public void SetCorrectlyQuestion()
    {
        RefreshPanels();
        SetQuestionPanel();
    }

    private void RefreshPanels()
    {
        videoQuestionScript.videoPanel.SetActive(false);
        imageQuestionScript.imagePanel.SetActive(false);
        textQuestionScript.textPanel.SetActive(false);
    }

    private void SetQuestionPanel()
    {
        switch (QuestionController.Instance.questionType[QuestionController.Instance.actualQuestion])
        {
            case 0:
                textQuestionScript.textPanel.SetActive(true);
                textQuestionScript.TextSet();
                break;

            case 1:
                imageQuestionScript.imagePanel.SetActive(true);
                imageQuestionScript.ImageSet();
                break;

            case 2:
                videoQuestionScript.videoPanel.SetActive(true);
                videoQuestionScript.MediaSet();
                break;
        }
    }

}
