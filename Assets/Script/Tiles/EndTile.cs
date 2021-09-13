using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTile : Tile
{
    public override void OnStand()
    {
        base.InvokeTileActionEvent(new TileAction(TileActionType.End));
    }
}
