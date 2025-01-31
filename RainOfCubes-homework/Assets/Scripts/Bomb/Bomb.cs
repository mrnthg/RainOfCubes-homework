using System;
using UnityEngine;

public class Bomb : PoolableObject
{
    private PreExplosionState _preExplosionState;

    public event Action<Bomb> BombRemoved;

    private void OnEnable()
    {
        _preExplosionState = GetComponent<PreExplosionState>();
        StartExplosionProcess();
    }

    public void StartExplosionProcess()
    {
        _preExplosionState.StartPreExplosionProcess();
    }

    public void OnRemove()
    {
        BombRemoved?.Invoke(this);
    }
}
