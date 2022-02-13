using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    private float expPoints;
    private Text level;
    public float points;
    public float levelNumb;
    public float increasedHealth;
    public float increasedDamage;

    Image expBar;
    // Start is called before the first frame update
    void Start()
    {
        expBar = GetComponent<Image>();
        expPoints = 75;
        increasedHealth = 0;
        increasedDamage = 0;
        level = GameObject.Find("Level").GetComponent<Text>();

        points = 0;
        levelNumb = 1;
        expBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ExpCount();
    }

    public void ExpCount()
    {
        if (points >= expPoints)
        {
            points = 0;
            levelNumb += 1;
            expPoints += 50;
            increasedHealth += 20;
            increasedDamage += 10;
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthUI>().maxHealth += increasedHealth;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Pattack>().playerAttackDamage += increasedDamage;
        }
        ExpValue(points);
        //expPoints.text = "Puntos EXP: " + points +"/200";
        level.text = "Nivel " + levelNumb;
    }

    void ExpValue(float value)
    {
        value /= expPoints;
        if(expBar != null)
        {
            expBar.fillAmount = value;
        }
        else
        {
            Debug.LogError("Exp Bar Not Found");
            return;
        }
        
    }
}
