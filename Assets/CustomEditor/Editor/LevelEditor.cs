using UnityEditor;
using UnityEngine;
public class LevelEditor : EditorWindow
{
    private const string TILE_INFORMATION_DATABASE_PATH = "../Bloxorz/Assets/Database/TileInformationDatabase.asset";

    private static TileInformationDatabase _tileDatabase;

    private const int MIN_SIZE = 5;
    private const int MAX_SIZE = 20;

    private int _nbColumn = 10;
    private int _nbRow = 10;

    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        LoadTileDatabase();
        GetWindow(typeof(LevelEditor));
    }


    private void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);
        GUILayout.Space(20);

        int _oldNbColumn = _nbColumn;
        int _oldNbRow = _nbRow;
        _nbColumn = EditorGUILayout.IntSlider("Number Of Columns", _nbColumn, MIN_SIZE, MAX_SIZE);
        _nbRow = EditorGUILayout.IntSlider("Number Of Rows", _nbRow, MIN_SIZE, MAX_SIZE);

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Save Your Level"))
        {
            SaveLevel();
        }

        if (_oldNbColumn != _nbColumn || _oldNbRow != _nbRow)
        {
            UpdateGrid();
        }
    }

    private void SaveLevel()
    {

    }

    private void UpdateGrid()
    {

    }

    private static void LoadTileDatabase()
    {
        _tileDatabase = AssetDatabase.LoadMainAssetAtPath(TILE_INFORMATION_DATABASE_PATH) as TileInformationDatabase;
    }
}
