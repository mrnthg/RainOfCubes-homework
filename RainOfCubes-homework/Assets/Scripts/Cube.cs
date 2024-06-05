using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;

    public event Action<Cube> cubeRemove;

    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private bool _isDestroyProcess = false;

    public bool isDestroyProcess => _isDestroyProcess;

    private void Awake()
    {
        SetStartMaterial();
    }

    public void OnRemove(Cube cube)
    {
        cubeRemove?.Invoke(cube);
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
        this.GetComponent<MaterialPool>().SetMaterial(this);
    }
}
