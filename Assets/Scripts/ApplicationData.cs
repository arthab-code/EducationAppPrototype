using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationData : MonoBehaviour
{
    [Header("LANGUAGE")]
    public string language = "pl";

    [Header("QUESTION DATA")]
    public string category;
    public string lesson;
    public string module;

    [Header("PATH DATA")]
    public string fileName;
    public string filePath;
    public string imagePath;
    public string videoPath;
    public string audioPath;
}
