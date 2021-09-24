using UnityEditor;
using UnityEngine;
public class LevelEditor : EditorWindow
{
    private const int MIN_SIZE = 5;
    private const int MAX_SIZE = 20;

    private int _nbColumn = 10;
    private int _nbRow = 10;

    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelEditor));
    }
    private void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);
        GUILayout.Space(20);

        GUILayout.Label("Number Of Columns", EditorStyles.boldLabel);
        _nbColumn = EditorGUILayout.IntSlider(_nbColumn, MIN_SIZE, MAX_SIZE);
        GUILayout.Label("Number Of Rows", EditorStyles.boldLabel);
        _nbRow = EditorGUILayout.IntSlider(_nbRow, MIN_SIZE, MAX_SIZE);

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Save Your Level"))
        {
            SaveLevel();
        }
    }

    private void SaveLevel()
    {

    }
}
