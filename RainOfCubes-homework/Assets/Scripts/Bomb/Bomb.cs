using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private int _minTransparence = 0;
    private int _maxTransparence = 1;
    private Color _startTransparence;
    private MeshRenderer _meshRenderer;
    private float _lifecycleTime;

    public event Action<Bomb> bombRemove;

    private void OnEnable()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _startTransparence = new Color(_meshRenderer.material.color.r, _meshRenderer.material.color.g, _meshRenderer.material.color.b, _maxTransparence);
        StartExplosionProcess();
    }

    public void StartExplosionProcess()
    {
        _lifecycleTime = GetTimeLifecycle();
        StartCoroutine(PreExplosionState());
    }

    private IEnumerator PreExplosionState()
    {
        float duration = 0;
        Color preExplosionColor = new Color(_startTransparence.r, _startTransparence.g, _startTransparence.b, _minTransparence);
       
        while (duration < _lifecycleTime)
        {
            duration += Time.deltaTime;

            _meshRenderer.material.color = Color.Lerp(_startTransparence, preExplosionColor, duration / _lifecycleTime);

            yield return null;
        }

        _meshRenderer.material.color = preExplosionColor;

        Explosion();
    }

    private void Explosion()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

        OnRemove();
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);
        List<Rigidbody> objects = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                objects.Add(hit.attachedRigidbody);

        return objects;
    }

    private void OnRemove()
    {
        bombRemove?.Invoke(this);
    }

    private int GetTimeLifecycle() => Random.Range(_minTimeLifecycle, _maxTimeLifecycle);
}
