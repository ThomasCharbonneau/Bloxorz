using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : Entity
{
    public event Action<TileAction> OnTileAction; 

    [SerializeField] private char _id = default;
    [SerializeField] private bool _twoCharNeeded = false;

    public char Id => _id;

    public virtual void OnPressed()
    {

    }

    public virtual void OnStand()
    {

    }

    public virtual void OnRelease()
    {

    }

    protected void InvokeTileActionEvent(TileAction tileAction)
    {
        OnTileAction?.Invoke(tileAction);
    }
}
