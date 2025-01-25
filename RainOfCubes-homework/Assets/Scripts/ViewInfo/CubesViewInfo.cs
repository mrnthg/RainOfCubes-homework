using UnityEngine;
using UnityEngine.UI;

public class CubesViewInfo : MonoBehaviour
{
    private const string SpawnCount = "SpawnCount: ";
    private const string CreateCount = "CreateCount: ";
    private const string ActiveCount = "ActiveCount: ";

    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Text _cubeSpawnCount;
    [SerializeField] private Text _cubeCreateCount;
    [SerializeField] private Text _cubeActiveCount;

    private void Update()
    {
        _cubeSpawnCount.text = SpawnCount + _cubeSpawner.CubeSpawnCount;
        _cubeCreateCount.text = CreateCount + _cubeSpawner.GetCountAllCubes();
        _cubeActiveCount.text = ActiveCount + _cubeSpawner.GetCountActiveCubes();
    }
}
