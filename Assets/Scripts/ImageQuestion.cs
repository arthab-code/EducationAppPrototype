using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class ImageQuestion : MonoBehaviour
{
    public GameObject imagePanel;
    public RawImage imageSource;
    public Text question;
    private Sprite sprite;
    private Texture2D texture;

    public void ImageSet()
    {
        SetQuestionText();
        ShowImage();
    }

    private void SetQuestionText()
    {
        question.text = QuestionController.Instance.question[QuestionController.Instance.actualQuestion];
    }

    private void ShowImage()
    {
        string tempPath ="";
        for (int i=0; i< QuestionController.Instance.imagePath[QuestionController.Instance.actualQuestion].Length-1; i++)
        {
            tempPath += QuestionController.Instance.imagePath[QuestionController.Instance.actualQuestion][i];
        }

        imageSource.texture = Resources.Load<Texture2D>(FileManager.Instance.pathData.GetImagePath()+tempPath);
    }
}
