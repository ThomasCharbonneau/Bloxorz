using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTile : Tile
{
    public override void OnPressed()
    {
        base.InvokeTileActionEvent(new TileAction(TileActionType.ResetPlayer));
    }

    public override void OnStand()
    {
        base.InvokeTileActionEvent(new TileAction(TileActionType.ResetPlayer));
    }
}
