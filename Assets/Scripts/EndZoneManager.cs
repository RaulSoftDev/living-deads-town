using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneManager : MonoBehaviour
{
    OnTriggerEvents eventManager;

    public bool ExitOpen;
    // Start is called before the first frame update
    void Start()
    {
        eventManager = GameObject.Find("ID_Card").GetComponent<OnTriggerEvents>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(eventManager.isHealtaken && other.tag == "Player")
        {
            Debug.Log("Salida activada");
            ExitOpen = true;
        }
    }

    private void LateUpdate()
    {
        if (ExitOpen)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(416.89f, 0.305f, 296.28f);
            ExitOpen = false;
        }
    }
}
