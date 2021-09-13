using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAction
{
    public TileActionType actionType;
    public Vector2 relatedTilePosition;
    public TileAction(TileActionType actionType, Vector2 relatedTilePosition = default)
    {
        this.actionType = actionType;
        this.relatedTilePosition = relatedTilePosition;
    }
}
