using System;
using UnityEngine;

public class PlatformCollisionHandler : MonoBehaviour
{
    private Cube _cube;

    public event Action CubeHited;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {        
            if (_cube.IsDestroyProcess == false)
            {
                _cube.ChangeColor();
                _cube.StartDestroyStatus();

                CubeHited?.Invoke();
            }
        }
    }
}
