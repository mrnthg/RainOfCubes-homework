using UnityEngine;
using Spawners;

public class BombSpawner : Spawner<Bomb>
{
    private Transform _cubePosition;
 
    public override void ActionOnGet(Bomb bomb)
    {
        bomb.gameObject.SetActive(true);

        bomb.transform.position = _cubePosition.position;
        bomb.GetComponent<Rigidbody>().velocity = Vector3.zero;

        bomb.BombRemoved += RemoveObject;
    }

    public override void OnRelease(Bomb bomb)
    {
        bomb.gameObject.SetActive(false);   
        
        bomb.BombRemoved -= RemoveObject;
    }

    public void GetCubePosition(Cube cube)
    {
        _cubePosition = cube.transform;
        GetPool();
    }
}
