using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public event Action<Level> OnTilesSpawned;
    public event Action<Tile> OnTileAdded;
    public event Action<Tile> OnTileRemoved;

    private const int _tileSize = 1;

    [SerializeField] Transform _tileAnchor = default;

    private static readonly Vector3 _hiddenLocation = new Vector3(-10000f, -10000f, 0);
    private Dictionary<char, Stack<Tile>> _pooledTiles = new Dictionary<char, Stack<Tile>>();
    private List<Tile> _activeTiles = new List<Tile>();

    private TileDatabase _tileDatabase = default;

    public void Init(TileDatabase tileDatabase)
    {
        _tileDatabase = tileDatabase;
    }

    public void ClearBoard()
    {
        foreach(var tile in _activeTiles)
        {
            PoolTile(tile);
        }
    }

    public IEnumerator SpawnBoard(Level level)
    {
        for (int i = 0; i < level.BoardTiles.Count; i++)
        {
            for (int j = 0; j < level.BoardTiles[i].Count; j++)
            {
                var tile = level.BoardTiles[i][j];
                if (tile is StartTile)
                {
                    level.startingPosition = new Vector2(i, j);
                }
                var newTile = GetTile(tile.Id);
                level.BoardTiles[i][j] = newTile; 
                SpawnTile(newTile, i, j);
                yield return new WaitForSeconds(0.02f);
            }
        }
        OnTilesSpawned.Invoke(level);
    }

    private void SpawnTile(Tile tile, int row, int column)
    {
        tile.gameObject.transform.position = new Vector3(_tileAnchor.position.x + row * _tileSize, _tileAnchor.position.y,
                                                         _tileAnchor.position.z + column * _tileSize);
    }

    private Tile GetTile(char id)
    {
        Tile tile = default;
        if (_pooledTiles.TryGetValue(id, out var tileList) && tileList.Count > 0 )
        {
            tile = tileList.Pop();
            tile.gameObject.SetActive(true);
        }
        else
        {
            tile = CreateTile(id);
        }

        _activeTiles.Add(tile);
        OnTileAdded?.Invoke(tile);
        return tile;
    }

    private Tile CreateTile(char id)
    {
        if (_tileDatabase.TryGetPrefab(id, out var tilePrefab))
        {
            /*switch (id)
            {
                case 'L':
                    return Instantiate(tilePrefab as LavaTile);
                case 'E':
                    return Instantiate(tilePrefab as EndTile);
                default:
                    return Instantiate(tilePrefab);
            }*/
            return Instantiate(tilePrefab, transform);
        }

        return default;
    }

    private void PoolTile(Tile tile)
    {
        OnTileRemoved?.Invoke(tile);
        if (!(_pooledTiles.TryGetValue(tile.Id, out var tileList) && tileList != null))
        {
            tileList = new Stack<Tile>();
            _pooledTiles.Add(tile.Id, tileList);
        }
        tileList.Push(tile);
    }

    private void HideTile(Tile tile)
    {
        tile.transform.position = _hiddenLocation;
        tile.gameObject.SetActive(false);
    }
}
