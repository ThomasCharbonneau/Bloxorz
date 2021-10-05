using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelSerializer
{
    private const string BASE_PATH = "../Bloxorz/Assets/LevelTextFiles/";
    private const string END_PATH = ".txt";

    private TileDatabase _tileDatabase;
    private LevelDatabase _levelDatabase;

    public LevelSerializer(LevelDatabase levelDatabase, TileDatabase tileDatabase)
    {
        _levelDatabase = levelDatabase;
        _tileDatabase = tileDatabase;
    }

    public List<Level> SerializeLevels()
    {
        List<Level> levelList = new List<Level>();
        foreach(var levelTextFile in _levelDatabase.LevelToTextFile)
        {
            levelList.Add(SerializeLevel(levelTextFile.Value, levelTextFile.Key));
        }
        return levelList;
    }

    private Level SerializeLevel(string textFileName, int id)
    {
        StreamReader inputStream = new StreamReader(BASE_PATH + textFileName + END_PATH);

        List<List<Tile>> tiles = new List<List<Tile>>();
        while(!inputStream.EndOfStream)
        {
            string rowText = inputStream.ReadLine();

            List<Tile> tileRow = new List<Tile>();
            for(int i = 0; i < rowText.Length; i++)
            {
                if (_tileDatabase.NeedTwoChars(rowText[i]))
                {
                    var tileFriend = rowText[++i];
                    // Parse next char
                }
                _tileDatabase.TryGetPrefab(rowText[i], out var tile);
                tileRow.Add(tile);
            }
            tiles.Add(tileRow);
        }

        return new Level(tiles, id);
    }
}
