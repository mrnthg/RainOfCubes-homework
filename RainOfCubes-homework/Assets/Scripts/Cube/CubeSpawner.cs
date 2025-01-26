using System.Collections.Generic;
using UnityEngine;
using Spawners;
using Random = UnityEngine.Random;

public class CubeSpawner : Spawner<Cube>
{
    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();

    private float _durationSpawn = 0f;
    private float _delaySpawn = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(GetPool), _durationSpawn, _delaySpawn);
    }

    public override void ActionOnGet(Cube cube)
    {
        cube.gameObject.SetActive(true);

        cube.transform.position = _pointsSpawn[RandomPoint()].position;
        cube.GetComponent<Rigidbody>().velocity = Vector3.zero;

        cube.CubeRemoved += RemoveObject;
        cube.CubeRemoved += _bombSpawner.GetCubePosition;
    }

    public override void OnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);

        cube.SetStartMaterial();
        cube.StopDestroyStatus();

        cube.CubeRemoved -= RemoveObject;
        cube.CubeRemoved -= _bombSpawner.GetCubePosition;
    }

    private int RandomPoint() => Random.Range(0, _pointsSpawn.Count);
}
