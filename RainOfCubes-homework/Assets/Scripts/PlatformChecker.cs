using System.Collections;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private Cube cube;
    private bool _isDestroyProcess = false;

    private void Start()
    {
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {        
            if (!_isDestroyProcess)
            {
                _isDestroyProcess = true;
                EventManager.OnCollision(gameObject.GetComponent<Cube>());
                StartCoroutine(DestroyCube());
            }
        }
    }

    private IEnumerator DestroyCube()
    {    
        yield return new WaitForSecondsRealtime(cube.GetTimeLifecycle());

        EventManager.OnRemove(cube);
    }
}
