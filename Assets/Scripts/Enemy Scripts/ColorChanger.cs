using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    SphereWithMaterialPropertyBlock[] colorSelect;
    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        colorSelect = GetComponentsInChildren<SphereWithMaterialPropertyBlock>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SphereWithMaterialPropertyBlock item in colorSelect)
        {
            item.Color1 = newColor;
        }
    }
}
