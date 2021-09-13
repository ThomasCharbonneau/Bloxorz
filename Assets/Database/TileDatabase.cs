using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileDatabase", menuName = "ScriptableObjects/TileDatabase", order = 1)]
public class TileDatabase : ScriptableObject
{
    [SerializeField] private Tile[] _tiles = default;
    /*[SerializeField] private Tile _tile = default;
    [SerializeField] private LavaTile _lavaTile = default;
    [SerializeField] private EndTile _endTile = default;
    [SerializeField] private StartTile _startTile = default;*/

    [System.NonSerialized] private Dictionary<char, Tile> _idToTiles = new Dictionary<char, Tile>();
    [System.NonSerialized] private HashSet<char> _twoCharsNeedingTile = new HashSet<char>();

    private void OnEnable()
    {
        foreach (var tile in _tiles)
        {
            _idToTiles.Add(tile.Id, tile);
        }
       /* _idToTiles.Add(_tile.Id, _tile);
        _idToTiles.Add(_lavaTile.Id, _lavaTile);
        _idToTiles.Add(_endTile.Id, _endTile);
        _idToTiles.Add(_startTile.Id, _startTile);*/    
    }

    public bool TryGetPrefab(char id, out Tile tile)
    {
        return _idToTiles.TryGetValue(id, out tile);
    }

    public bool NeedTwoChars(char id)
    {
        return _twoCharsNeedingTile.Contains(id);
    }
}
