using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();
    
    private int _defaultSize = 10;
    private int _maxSize = 10;
    private float _durationSpawn = 0f;
    private float _delaySpawn = 1f;
    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(CreateCube, ActionOnGet, OnRelease, Destroy, true, _defaultSize, _maxSize);
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetPool), _durationSpawn, _delaySpawn);
    }

    private Cube CreateCube()
    {
        Cube newCube = Instantiate(_cubePrefab);
        newCube.transform.SetParent(transform);
        newCube.cubeRemove += RemoveCube;
        return newCube;
    }

    private void GetPool()
    {
        _pool.Get();
    }

    private void OnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.SetStartMaterial();
        cube.StopDestroyStatus();
    }

    private void ActionOnGet(Cube cube)
    {
        cube.transform.position = _pointsSpawn[RandomPoint()].position;
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cube.gameObject.SetActive(true);    
    }

    private void RemoveCube(Cube cube)
    {
        _pool.Release(cube);
    }

    private int RandomPoint() => Random.Range(0, _pointsSpawn.Count);
}
