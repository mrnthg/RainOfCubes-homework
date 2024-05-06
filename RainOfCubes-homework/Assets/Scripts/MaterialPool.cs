using System.Collections.Generic;
using UnityEngine;

public class MaterialPool : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();

    public Material GetMaterial()
    {
        Material material;

        material = _materials[RandomCountMaterial()];
        return material;
    }

    private int RandomCountMaterial() => Random.Range(0, _materials.Count);
}
