using UnityEditor;
using UnityEngine;
public class LevelEditor : EditorWindow
{
    [MenuItem("Tools/GUID Finder")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelEditor));
    }
    private void OnGUI()
    {
        GUILayout.Label("GUID Reference Finder", EditorStyles.boldLabel);
    }
}
