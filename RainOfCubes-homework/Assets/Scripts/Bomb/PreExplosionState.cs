using System.Collections;
using UnityEngine;

public class PreExplosionState : MonoBehaviour
{
    private int _minTimeLifecycle = 2;
    private int _maxTimeLifecycle = 6;
    private int _minTransparence = 0;
    private int _maxTransparence = 1;
    private Color _startTransparence;
    private MeshRenderer _meshRenderer;
    private Exploder _exploder;
    private float _lifecycleTime;

    private void Awake()
    {  
        _exploder = GetComponent<Exploder>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _startTransparence = new Color(_meshRenderer.material.color.r, _meshRenderer.material.color.g, _meshRenderer.material.color.b, _maxTransparence);    
    }

    public void StartPreExplosionProcess()
    {
        _lifecycleTime = GetTimeLifecycle();     
        StartCoroutine(ColorChanger());
    }

    private IEnumerator ColorChanger()
    {
        float duration = 0;
        Color preExplosionColor = new Color(_startTransparence.r, _startTransparence.g, _startTransparence.b, _minTransparence);

        while (duration < _lifecycleTime)
        {
            duration += Time.deltaTime;
            
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = Color.Lerp(_startTransparence, preExplosionColor, duration / _lifecycleTime);
            }
            
            yield return null;
        }

        _meshRenderer.material.color = preExplosionColor;

        _exploder.Explosion();
    }

    private int GetTimeLifecycle() =>
        Random.Range(_minTimeLifecycle, _maxTimeLifecycle);
}
