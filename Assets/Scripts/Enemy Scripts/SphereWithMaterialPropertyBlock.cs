using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereWithMaterialPropertyBlock : MonoBehaviour
{
    public Color Color1;

    private Renderer renderer;
    private MaterialPropertyBlock propBlock;

    void Start()
    {
        propBlock = new MaterialPropertyBlock();
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        renderer.material.SetColor("_Color", Color1);
    }
}
