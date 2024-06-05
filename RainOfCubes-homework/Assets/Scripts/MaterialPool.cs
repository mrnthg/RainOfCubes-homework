using System.Collections.Generic;
using UnityEngine;

public class MaterialPool : MonoBehaviour
{
    [SerializeField] private List<Material> _materials = new List<Material>();

    public void SetMaterial(Cube cube)
    {
        if (cube.TryGetComponent(out MeshRenderer material))
        {
            cube.GetComponent<MeshRenderer>().material = _materials[RandomNumber()];
        }
    }

    private int RandomNumber() => Random.Range(0, _materials.Count);
}
