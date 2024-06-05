using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;

    private Cube cube;
    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private bool _isDestroyProcess = false;

    public event Action<Cube> cubeRemove;

    public bool IsDestroyProcess => _isDestroyProcess;   

    private void Awake()
    {
        cube = GetComponent<Cube>();
        SetStartMaterial();
    }

    public void OnRemove()
    {
        cubeRemove?.Invoke(this);
    }

    public int GetTimeLifecycle() => UnityEngine.Random.Range(_minTimeLifecycle, _maxTimeLifecycle);

    public void SetStartMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = _startMaterial;
    }

    public void ÑhangeDestroyStatus(bool isDestroy)
    {
        _isDestroyProcess = isDestroy;
    }

    public void ChangeColor()
    {
        GetComponent<MaterialPool>().SetMaterial(cube);
    }
}
