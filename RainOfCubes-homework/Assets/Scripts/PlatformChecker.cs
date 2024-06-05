using System;
using System.Collections;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    public event Action<Cube> OnCollision;

    private Cube cube;

    private void Start()
    {
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {        
            if (!cube.isDestroyProcess)
            {
                cube.ChangeColor();
                OnCollision?.Invoke(cube);
                cube.ÑhangeDestroyStatus(true);

                StartCoroutine(DestroyCube());
            }
        }
    }

    private IEnumerator DestroyCube()
    {
        yield return new WaitForSecondsRealtime(cube.GetTimeLifecycle());

        cube.OnRemove(cube);
    }
}
