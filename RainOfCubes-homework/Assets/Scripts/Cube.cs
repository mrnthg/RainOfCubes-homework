using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material _startMaterial;

    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;

    private void Awake()
    {
        SetMaterial();
    }

    public int GetTimeLifecycle() => Random.Range(_minTimeLifecycle, _maxTimeLifecycle);

    public void SetMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = _startMaterial;
    }
}
