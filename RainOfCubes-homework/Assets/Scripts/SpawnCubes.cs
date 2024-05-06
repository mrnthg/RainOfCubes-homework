using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    [SerializeField] private CubeLifecycle _prefab;
    [SerializeField] private List<Transform> _pointsSpawn = new List<Transform>();

    private float _durationSpawn = 1f;

    void Start()
    {
        StartCoroutine(CreateCubes());
    }

    private IEnumerator CreateCubes()
    {
        var duration = new WaitForSeconds(_durationSpawn);

        while (true)
        {
            Vector3 position = _pointsSpawn[RandomPoint()].position;           

            Instantiate(_prefab, position, Quaternion.identity);

            yield return duration;
        }
    }

    private int RandomPoint() => Random.Range(0, _pointsSpawn.Count);
}
