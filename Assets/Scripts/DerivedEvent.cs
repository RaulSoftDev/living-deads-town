using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DerivedEvent : MonoBehaviour
{
    public bool finishedOut;
    public bool levelFinished;

    public GameObject roundsUpGO;
    public GameObject eventManager;
    public GameObject cronometer;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FadeOutEnd()
    {
        finishedOut = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            levelFinished = true;
        }
    }

    /*public void RoundUp()
    {
        StartCoroutine(roundBegins());
    }*/

    IEnumerator roundBegins()
    {
        //Sacamos texto de oleada
        roundsUpGO.GetComponent<Animator>().SetBool("RoundActive", true);
        yield return new WaitForSeconds(2.55f);
        roundsUpGO.GetComponent<Animator>().SetBool("RoundActive", false);
        //Indicamos el tiempo del reloj
        eventManager.GetComponent<EventManager>().minutes = 2;
        eventManager.GetComponent<EventManager>().seconds = 0;
        //Aparece el reloj
        cronometer.GetComponent<Animator>().SetBool("TimeOn", true);
        //Empieza la cuenta-atrás
        eventManager.GetComponent<EventManager>().timeStops = false;
    }
}
