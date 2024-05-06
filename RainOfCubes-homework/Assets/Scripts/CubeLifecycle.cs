using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLifecycle : MonoBehaviour
{
    [SerializeField] private MaterialPool _material;

    private float _durationTime;
    private float _minTime = 2;
    private float _maxTime = 6;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TouchCheck"))
        {
            gameObject.GetComponent<Renderer>().material = _material.GetMaterial();
            _durationTime = RandomTime();

            StartCoroutine(DestroyCube());
        }
    }

    private IEnumerator DestroyCube()
    {
        yield return new WaitForSecondsRealtime(_durationTime);

        Destroy(gameObject);
    }

    private float RandomTime() => Random.Range(_minTime, _maxTime);
}
