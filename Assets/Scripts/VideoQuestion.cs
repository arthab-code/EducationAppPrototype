using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoQuestion : MonoBehaviour
{
    public GameObject videoPanel;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    public Text question;

    private void Start()
    {
        videoPlayer = videoPanel.GetComponent<VideoPlayer>();
        audioSource = videoPanel.GetComponent<AudioSource>();
    }

    public void MediaSet()
    {
        VideoPlayerController.Instance.ResetMediaSettings();
        ShowMedia();
        SetQuestionText();
    }
    private void ShowMedia()
    {
        string tempPath = "";
        for (int i = 0; i < QuestionController.Instance.videoPath[QuestionController.Instance.actualQuestion].Length - 1; i++)
        {
            tempPath += QuestionController.Instance.videoPath[QuestionController.Instance.actualQuestion][i];
        }

        videoPlayer.clip = Resources.Load<VideoClip>(FileManager.Instance.pathData.GetVideoPath()+tempPath);
        videoPlayer.Play();


        tempPath = "";
        for (int i = 0; i < QuestionController.Instance.audioPath[QuestionController.Instance.actualQuestion].Length - 1; i++)
        {
            tempPath += QuestionController.Instance.audioPath[QuestionController.Instance.actualQuestion][i];
        }

        audioSource.clip = Resources.Load<AudioClip>(FileManager.Instance.pathData.GetAudioPath() + tempPath);
        audioSource.Play();
    }

    private void SetQuestionText()
    {
        question.text = QuestionController.Instance.question[QuestionController.Instance.actualQuestion];
    }
}
