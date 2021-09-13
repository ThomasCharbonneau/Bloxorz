using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelBoard", menuName = "ScriptableObjects/LevelBoard", order = 1)]
public class LevelBoard : ScriptableObject
{
    [System.Serializable]
    public class Row
    {
        [SerializeField] private char[] _tiles = default;
    }
    [SerializeField] private Row[] _levelRows = default;
}
