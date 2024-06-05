using System.Collections.Generic;
using UnityEngine;

public class MaterialPool : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();

    private void OnEnable()
    {
        EventManager.cubeCollision += SetMaterial;
    }

    private void OnDisable()
    {
        EventManager.cubeCollision -= SetMaterial;
    }

    private void SetMaterial(Cube cube)
    {
        if (cube.TryGetComponent(out MeshRenderer material))
        {
            material.material = _materials[RandomNumber()];
        }
    }

    private int RandomNumber() => Random.Range(0, _materials.Count);
}
