using System;
using System.Collections;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private Cube _cube;

    public event Action<Cube> OnCollision;

    private void Start()
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
                _cube.ÑhangeDestroyStatus(true);

                StartCoroutine(DestroyCube());
            }
        }
    }

    private IEnumerator DestroyCube()
    {
        yield return new WaitForSecondsRealtime(_cube.GetTimeLifecycle());

        _cube.OnRemove();
    }
}
