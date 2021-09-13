using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] private LevelDatabase _levelDatabase = default;
    [SerializeField] private TileDatabase _tileDatabase = default;
    [SerializeField] private LevelSpawner _levelSpawner = default;


    private LevelSerializer _levelSerializer;
    private List<Level> _levels;

    private int _currentLevelIndex = -1;

    public static GameScene Instance;
    public static Player CurrentPlayer;
    public static Level CurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _levelSerializer = new LevelSerializer(_levelDatabase, _tileDatabase);
        _levelSpawner.Init(_tileDatabase);
        _levels = _levelSerializer.SerializeLevels();
        SpawnNextLevel();
    }

    public void SpawnNextLevel()
    {
        _levelSpawner.SpawnLevel(_levels[++_currentLevelIndex]);
    }
}
