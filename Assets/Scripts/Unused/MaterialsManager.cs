using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsManager : MonoBehaviour
{
    public int countWood, countPlastic, countCopper, countRubber, countStone;
    private Text woodText, plasticText, copperText, rubberText, stoneText;

    // Start is called before the first frame update
    void Start()
    {
        woodText = GameObject.FindGameObjectWithTag("TextWood").GetComponent<Text>();
        plasticText = GameObject.FindGameObjectWithTag("TextPlastic").GetComponent<Text>();
        copperText = GameObject.FindGameObjectWithTag("TextCopper").GetComponent<Text>();
        rubberText = GameObject.FindGameObjectWithTag("TextRubber").GetComponent<Text>();
        stoneText = GameObject.FindGameObjectWithTag("TextStone").GetComponent<Text>();
        countWood = 0;
        countPlastic = 0;
        countRubber = 0;
        countStone = 0;
        countCopper = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        //SetCountText();
    }

    /*void SetCountText()
    {
        woodText.text = "Madera: " + countWood.ToString();
        plasticText.text = "Plástico: " + countPlastic.ToString();
        copperText.text = "Cobre: " + countCopper.ToString();
        rubberText.text = "Goma: " + countRubber.ToString();
        stoneText.text = "Piedra: " + countStone.ToString();
    }*/
}
