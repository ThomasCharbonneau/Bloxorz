using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileInformationDatabase", menuName = "ScriptableObjects/TileInformationDatabase", order = 1)]
public class TileInformationDatabase : ScriptableObject
{
    [SerializeField] public TileInformation[] Tiles = default;
}
