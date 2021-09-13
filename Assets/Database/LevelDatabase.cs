using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDatabase", menuName = "ScriptableObjects/LevelDatabase", order = 1)]
public class LevelDatabase : ScriptableObject
{
    [SerializeField] private string[] _levelTextFileNames = default;

    public Dictionary<int, string> LevelToTextFile = new Dictionary<int, string>();

    private void OnEnable()
    {
        for (int i = 0; i < _levelTextFileNames.Length; i++)
        {
            LevelToTextFile.Add(i, _levelTextFileNames[i]);
        }
    }
}
