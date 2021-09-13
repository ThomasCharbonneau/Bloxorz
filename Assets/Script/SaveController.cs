using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SaveController
{
    public static void UpdateCurrentLevel(int levelIndex)
    {
        string path = Application.dataPath;
        StreamWriter sw = new StreamWriter(path + "save.txt");
        sw.WriteLine(levelIndex);
        sw.Close();
    }

    public static int GetCurrentLevel()
    {
        return GetLevelFromSaveFile();
    }
    
    private static int GetLevelFromSaveFile()
    {
        string path = Application.dataPath;
        try
        {
            string levelIndex = System.IO.File.ReadAllText(path + "save.txt");
            return int.Parse(levelIndex);
        }
        catch (System.IO.IOException exception)
        {
            Debug.Log("BOO");
            UpdateCurrentLevel(0);
        }

        return 0;   
    }
}
