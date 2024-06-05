using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<Cube> cubeCollision;
    public static event Action<Cube> cubeRemove;

    public static void OnCollision(Cube cube)
    {
        cubeCollision?.Invoke(cube);
    }

    public static void OnRemove(Cube cube)
    {
        cubeRemove?.Invoke(cube);
    }
}
