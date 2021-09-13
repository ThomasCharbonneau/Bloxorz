using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private Player _playerPrefab = default;
    [SerializeField] private TileSpawner _tileSpawner = default;

    private TileDatabase _tileDatabase = default;
    
    public static Level CurrentLevel = null;

    public void Init(TileDatabase tileDatabase)
    {
        _tileDatabase = tileDatabase;
        _tileSpawner.Init(tileDatabase);
        _tileSpawner.OnTilesSpawned += OnTilesSpawned;
    }
    
    public void SpawnLevel(Level level)
    {
        _tileSpawner.ClearBoard();
        StartCoroutine(_tileSpawner.SpawnBoard(level));
    }

    private void OnTilesSpawned(Level level)
    {
        GameScene.CurrentLevel = level;
        if (GameScene.CurrentPlayer == null)
        {
            Player player = Instantiate(_playerPrefab);
            GameScene.CurrentPlayer = player;
        }
        GameScene.CurrentPlayer.SetInitialPosition((int)level.startingPosition.x, (int)level.startingPosition.y);
    }

    public void OnDestroy()
    {
        _tileSpawner.OnTilesSpawned -= OnTilesSpawned;
    }
}
