using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class Cube : PoolableObject
{
    [SerializeField] private Material _startMaterial;

    private MeshRenderer _meshRenderer;
    private MaterialPool _materialPool;
    private PlatformCollisionHandler _collisionHandler;
    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private bool _isDestroyProcess = false;

    public event Action<Cube> CubeRemoved;

    public bool IsDestroyProcess => _isDestroyProcess;   

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materialPool = GetComponent<MaterialPool>();
        _collisionHandler = GetComponent<PlatformCollisionHandler>();

        SetStartMaterial();
        _collisionHandler.CubeHited += DestroyCube;
    }

    private void OnDestroy()
    {
        _collisionHandler.CubeHited -= DestroyCube;
    }

    public void OnRemove()
    {
        CubeRemoved?.Invoke(this);
    }

    public int GetTimeLifecycle() => 
        Random.Range(_minTimeLifecycle, _maxTimeLifecycle);

    public void SetStartMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }

    public void StartDestroyStatus()
    {
        _isDestroyProcess = true;
    }

    public void StopDestroyStatus()
    {
        _isDestroyProcess = false;
    }

    public void ChangeColor()
    {
        _materialPool.SetMaterial(this);
    }

    private void DestroyCube()
    {
        StartCoroutine(StartDestroyProcess());
    }

    private IEnumerator StartDestroyProcess()
    {
        yield return new WaitForSecondsRealtime(GetTimeLifecycle());
        
        OnRemove();     
    }
}
