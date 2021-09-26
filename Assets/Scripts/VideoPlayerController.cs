using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : Singleton<VideoPlayerController>
{
    public GameObject videoPanel;
    public Button startButton;
    public Button pauseButton;
    public Slider videoSlider;
    public bool isDragged = false;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private float sliderValueTemp = 0;
    void Start()
    {
        startButton.onClick.AddListener(delegate
        {
            StartVideo();
        });
        pauseButton.onClick.AddListener(delegate
        {
            PauseVideo();
        });
        videoPlayer = videoPanel.GetComponent<VideoPlayer>();
        audioSource = videoPanel.GetComponent<AudioSource>();
    }
    

    void Update()
    {
       if (isDragged == true)
        {
            OnDragHandler();

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                OnUpHandler();
                isDragged = false;
            }
        } else
        {
            if (videoPlayer.frameCount > 0)
            {
                videoSlider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
                sliderValueTemp = videoSlider.value;
            }
        }
    }
    private void PauseVideo()
    {
        videoPlayer.Pause();
        audioSource.Pause();
        startButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

    }

    private void StartVideo()
    {
        videoPlayer.Play();
        audioSource.Play();
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

    }
    private void OnDragHandler()
    {
        sliderValueTemp = videoSlider.value;
        videoPlayer.frame = (long)(videoPlayer.frameCount * sliderValueTemp);
        audioSource.time = (audioSource.clip.length * sliderValueTemp);
    }

    private void OnUpHandler()
    {
        videoSlider.value = sliderValueTemp;
        videoPlayer.frame = (long)(videoPlayer.frameCount * sliderValueTemp);
        audioSource.time = (audioSource.clip.length * sliderValueTemp);
    }

    public void ResetMediaSettings()
    {
        startButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        videoSlider.value = 0;
        videoPlayer.frame = 0;
        audioSource.time = 0;
    }

}
