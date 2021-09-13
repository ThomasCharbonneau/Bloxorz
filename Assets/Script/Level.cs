using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<List<Tile>> BoardTiles;
    public int Id;
    public Vector2 startingPosition;

    public Level(List<List<Tile>> boardTiles, int id)
    {
        BoardTiles = boardTiles;
        Id = id;
    }
}
