using System.Collections;
using UnityEngine;

public class PlatformChecker : MonoBehaviour
{
    private Cube _cube;
    private float _lifecycleTime;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
        _lifecycleTime = _cube.GetTimeLifecycle();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {        
            if (_cube.IsDestroyProcess == false)
            {
                _cube.ChangeColor();
                _cube.StartDestroyStatus();

                StartCoroutine(DestroyCube());
            }
        }
    }

    private IEnumerator DestroyCube()
    {
        yield return new WaitForSecondsRealtime(_lifecycleTime);

        _cube.OnRemove();
    }
}
