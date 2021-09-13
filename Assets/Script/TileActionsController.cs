using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileActionsController : MonoBehaviour
{
    [SerializeField] GameScene _gameScene = default;
    [SerializeField] TileSpawner _tileSpawner = default;

    private void Awake()
    {
        _tileSpawner.OnTileAdded += OnTileAdded;
        _tileSpawner.OnTileRemoved += OnTileRemoved;
    }

    private void OnTileAdded(Tile tile)
    {
        tile.OnTileAction += OnActionReceived;
    }

    private void OnTileRemoved(Tile tile)
    {
        tile.OnTileAction -= OnActionReceived;
    }
    public void OnActionReceived(TileAction tileAction)
    {
        switch (tileAction.actionType)
        {
            case TileActionType.ResetPlayer:
                StartCoroutine(GameScene.CurrentPlayer.OnDeath());
                break;
            case TileActionType.End:
                LoadNextLevel();
                break;
            case TileActionType.TriggerBridge:
            default:
                break;
        }
    }

    private void LoadNextLevel()
    {
        _gameScene.SpawnNextLevel();
    }
}
