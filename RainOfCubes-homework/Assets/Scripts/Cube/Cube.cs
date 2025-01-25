using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;

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
        SetStartMaterial();
    }

    public void OnRemove()
    {
        cubeRemove?.Invoke(this);
    }

    public int GetTimeLifecycle() => Random.Range(_minTimeLifecycle, _maxTimeLifecycle);

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
}
