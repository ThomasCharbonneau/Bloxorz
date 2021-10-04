using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileInformation", menuName = "ScriptableObjects/TileInformation", order = 1)]
public class TileInformation : ScriptableObject
{
    [SerializeField] private string _tileName = default;
    [SerializeField] private char _tileChar = default;
    [SerializeField] private Sprite _tileSprite = default;
}
