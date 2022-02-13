using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    public float smoothSpeed = 0.125f;
    float transformX;
    float transformY;
    public Vector3 offset;

    public bool OnPlay = false;
    public bool eventEnd = false;
    bool endAnim1 = false;

    /*public GameObject screenOn;
    public GameObject screenOff;
    public GameObject cameraUI;*/

    Animator mainCameraAnim;
    EventManager eventManager;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else
        {
            Debug.LogError("Player Not Found");
            return;
        }
        
        mainCameraAnim = GetComponent<Animator>();

        if(GameObject.Find("EventManager") != null)
        {
            eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
        }
        else
        {
            Debug.LogError("EventManager Not Found");
            return;
        }
       
    }

    private void LateUpdate()
    {
        if (OnPlay)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(target);
            transform.rotation = Quaternion.Euler(83.641f, 0, 0);
        }

        if (eventEnd)
        {
            //StartCoroutine(FadeEvent());
        }

        /*if (!eventManager.scene1Active && !mainCameraAnim.GetCurrentAnimatorStateInfo(0).IsName("BeginPlay") && mainCameraAnim.enabled)
        {
            screenOff.GetComponent<CanvasGroup>().alpha = 1;
        }*/
    }

    /*void LetsPlay()
    {
        screenOff.SetActive(false);
        screenOn.SetActive(false);
        cameraUI.SetActive(false);
        mainCameraAnim.enabled = false;
        OnPlay = true;
    }*/

    void EndingAnimation1()
    {
        eventManager.scene1Active = false;
        //endAnim1 = true;
    }

    void CameraEventEnded()
    {

        eventEnd = true;
    }

    IEnumerator FadeEvent()
    {
        GameObject.Find("FadeEffects").GetComponent<Animator>().SetBool("In", true);
        yield return new WaitForSecondsRealtime(5f);
        //GameObject.Find("FadeEffects").GetComponent<Animator>().SetBool("In", false);
        GameObject.Find("EventManager").GetComponent<EventManager>().fadeEffects.GetComponent<Animator>().SetBool("Out", true);
    }
}
