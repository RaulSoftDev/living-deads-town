using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPOny : MonoBehaviour
{
    int valorTest;
    public int valorTest2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValorPrueba();
    }

    private void ValorPrueba()
    {
        if (valorTest2 > 1)
        {
            valorTest++;
            Debug.Log(valorTest);
        }
    }
}
