using UnityEditor;
using UnityEngine;
public class LevelEditor : EditorWindow
{
    private const string TILE_INFORMATION_DATABASE_PATH = "Assets/Database/TileInformation/TileInformationDatabase.asset";

    private TileInformationDatabase _tileDatabase;
    private string[] _tilesName;

    private const int MIN_SIZE = 5;
    private const int MAX_SIZE = 20;

    private int _nbColumn = 10;
    private int _nbRow = 10;

    private int _tileSelectedIndex = 0;

    [MenuItem("Tools/Level Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(LevelEditor));
    }


    private void OnGUI()
    {
        if (_tileDatabase == null)
        {
            LoadTileDatabase();
        }

        GUILayout.Label("Level Editor", EditorStyles.boldLabel);
        GUILayout.Space(20);

        int _oldNbColumn = _nbColumn;
        int _oldNbRow = _nbRow;
        _nbColumn = EditorGUILayout.IntSlider("Number Of Columns", _nbColumn, MIN_SIZE, MAX_SIZE);
        _nbRow = EditorGUILayout.IntSlider("Number Of Rows", _nbRow, MIN_SIZE, MAX_SIZE);


        GUILayout.Space(10);
        _tileSelectedIndex = EditorGUILayout.Popup("Selected Tile Type", _tileSelectedIndex, _tilesName);

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

    private void LoadTileDatabase()
    {
        _tileDatabase = AssetDatabase.LoadMainAssetAtPath(TILE_INFORMATION_DATABASE_PATH) as TileInformationDatabase;
        _tilesName = new string[_tileDatabase.Tiles.Length];
        for(int i = 0; i < _tileDatabase.Tiles.Length; i++)
        {
            _tilesName[i] = _tileDatabase.Tiles[i].name;
        }
    }
}
