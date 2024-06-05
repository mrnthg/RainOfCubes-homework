using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;

    private Cube _cube;
    private MeshRenderer _meshRenderer;
    private MaterialPool _materialPool;
    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private bool _isDestroyProcess = false;

    public event Action<Cube> cubeRemove;

    public bool IsDestroyProcess => _isDestroyProcess;   

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _materialPool = GetComponent<MaterialPool>();
        _cube = GetComponent<Cube>();
        SetStartMaterial();
    }

    public void OnRemove()
    {
        cubeRemove?.Invoke(this);
    }

    public int GetTimeLifecycle() => UnityEngine.Random.Range(_minTimeLifecycle, _maxTimeLifecycle);

    public void SetStartMaterial()
    {
        _meshRenderer.material = _startMaterial;
    }

    public void ÑhangeDestroyStatus(bool isDestroy)
    {
        _isDestroyProcess = isDestroy;
    }

    public void ChangeColor()
    {
        _materialPool.SetMaterial(_cube);
    }
}
