using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileInformation", menuName = "ScriptableObjects/TileInformation", order = 1)]
public class TileInformation : ScriptableObject
{
    [SerializeField] public string TileName = default;
    [SerializeField] public char TileChar = default;
    [SerializeField] public Texture TileSprite = default;
}
