using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    private Image health_UI;
    private Image health_npc_UI;
    private Canvas mainCanvas;

    public float maxHealth = 100f;
    public float maxNPCHealth = 100f;

    void Awake() {
        health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        health_npc_UI = Transform.FindObjectOfType<Image>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (health_npc_UI == null)
        {
            Debug.LogError("No Health Bar attached");
        }
    }

    public void DisplayHealth(float value) {

        value /= maxHealth;

        if (value < 0f)
            value = 0f;

        health_UI.fillAmount = value;

    }

    public void DisplayNPCHealth(float value)
    {
        value /= maxNPCHealth;

        if (value < 0f)
            value = 0f;

        health_npc_UI.fillAmount = value;
    }


} // class

































