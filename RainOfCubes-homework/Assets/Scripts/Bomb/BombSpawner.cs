using UnityEngine;
using Spawners;

public class BombSpawner : Spawner<Bomb>
{
    private Transform _cubePosition;
    private int _bombSpawnCount = 0;

    public int BombSpawnCount => _bombSpawnCount;
    public override void ActionOnGet(Bomb bomb)
    {
        bomb.gameObject.SetActive(true);

        _bombSpawnCount++;

        bomb.transform.position = _cubePosition.position;
        bomb.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bomb.bombRemove += RemoveObject;
    }

    public override void OnRelease(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);       
        bomb.bombRemove -= RemoveObject;
    }

    public void GetCubePosition(Cube cube)
    {
        _cubePosition = cube.transform;
        GetPool();
    }

    public int GetCountActiveBombs()
    {
        return GetCountActiveObjects();
    }

    public int GetCountAllBombs()
    {
        return GetCountAllObjects();
    }
}
