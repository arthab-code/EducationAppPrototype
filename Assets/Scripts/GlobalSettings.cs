using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : Singleton<GlobalSettings>
{
    public string language = "en";
    public string category;
    public string lesson;
    public string module;
}
