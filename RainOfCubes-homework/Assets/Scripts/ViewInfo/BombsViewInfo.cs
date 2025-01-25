using UnityEngine;
using UnityEngine.UI;

public class BombsViewInfo : MonoBehaviour
{
    private const string SpawnCount = "SpawnCount: ";
    private const string CreateCount = "CreateCount: ";
    private const string ActiveCount = "ActiveCount: ";

    [SerializeField] private BombSpawner _bombSpawner;
    [SerializeField] private Text _bombSpawnCount;
    [SerializeField] private Text _bombCreateCount;
    [SerializeField] private Text _bombActiveCount;

    private void Update()
    {
        _bombSpawnCount.text = SpawnCount + _bombSpawner.BombSpawnCount;
        _bombCreateCount.text = CreateCount + _bombSpawner.GetCountAllBombs();
        _bombActiveCount.text = ActiveCount + _bombSpawner.GetCountActiveBombs();
    }
}
