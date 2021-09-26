
public class PathData
{
    private string fileName;
    private string filePath;
    private string imagePath;
    private string videoPath;
    private string audioPath;

    public void SetFileName(string language, string category, string lesson, string module)
    {
        fileName = language + "_" + category + "_" + lesson + "_" + module;
    }

    public void SetFilePath(string language, string category, string lesson, string module)
    {
        filePath = "FileData/category_" + category + "/" + "lesson_" + lesson + "/" + "module_" + module + "/";
    }

    public string GetFileName()
    {
        return fileName;
    }

    public string GetFilePath()
    {
        return filePath;
    }

    public string GetImagePath()
    {
        return imagePath = "FileData/category_" + GlobalSettings.Instance.category + "/" + "lesson_" + GlobalSettings.Instance.lesson + "/" + "module_" + GlobalSettings.Instance.module + "/image/";
    }

    public string GetVideoPath()
    {
        return videoPath = "FileData/category_" + GlobalSettings.Instance.category + "/" + "lesson_" + GlobalSettings.Instance.lesson + "/" + "module_" + GlobalSettings.Instance.module + "/video/"; ;
    }

    public string GetAudioPath()
    {
        return audioPath = "FileData/category_" + GlobalSettings.Instance.category + "/" + "lesson_" + GlobalSettings.Instance.lesson + "/" + "module_" + GlobalSettings.Instance.module + "/audio/"; ;
    }


}