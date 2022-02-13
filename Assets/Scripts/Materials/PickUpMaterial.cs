using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMaterial : MonoBehaviour
{
    #region Variables
    private Transform playerCharacter;
    public float speed;
    private bool pickedUp = false;
    private MaterialsManager pickCount;
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;
    public float destroy;
    private bool OnCountOn = false;
    #endregion

    private void Start()
    {
        boxCollider = GetComponentInChildren<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pickCount = GameObject.FindGameObjectWithTag("Materials").GetComponent<MaterialsManager>();
    }

    private void Update()
    {
        if (pickedUp)
        {
            Picked();
        }

        if (OnCountOn)
        {
            CountUp();
            OnCountOn = false;
        }
        
    }

    private void OnTriggerEnter(Collider character)
    {
        if(character.tag == "Player")
        {
            pickedUp = true;
            OnCountOn = true;
        }
    }

    void Picked()
    {
        boxCollider.enabled = false;
        PickMaterialsUp();
    }

    #region Pick Materials and delete
    IEnumerator DeleteWood()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);
        transform.LookAt(playerCharacter.position);
        yield return new WaitForSecondsRealtime(destroy);
        Destroy(gameObject);
    }

    IEnumerator DeleteStone()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);
        transform.LookAt(playerCharacter.position);
        yield return new WaitForSecondsRealtime(destroy);
        Destroy(gameObject);
    }

    IEnumerator DeletePlastic()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);
        transform.LookAt(playerCharacter.position);
        yield return new WaitForSecondsRealtime(destroy);
        Destroy(gameObject);
    }

    IEnumerator DeleteCopper()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);
        transform.LookAt(playerCharacter.position);
        yield return new WaitForSecondsRealtime(destroy);
        Destroy(gameObject);
    }

    IEnumerator DeleteRubber()
    {
        float step = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);
        transform.LookAt(playerCharacter.position);
        yield return new WaitForSecondsRealtime(destroy);
        Destroy(gameObject);
    }

    void PickMaterialsUp()
    {
        if (gameObject.name == "Wood")
        {
            StartCoroutine("DeleteWood");
        }
        else if (gameObject.name == "Stone")
        {
            StartCoroutine("DeleteStone");
        }
        else if(gameObject.name == "Plastic")
        {
            StartCoroutine("DeletePlastic");
        }
        else if(gameObject.name == "Copper")
        {
            StartCoroutine("DeleteCopper");
        }
        else if(gameObject.name == "Rubber")
        {
            StartCoroutine("DeleteRubber");
        }

    }
    #endregion

    #region Count Up Materials
    void CountUp()
    {
        if (gameObject.name == "Wood")
        {
            StartCoroutine("CountingWood");
        }
        else if (gameObject.name == "Stone")
        {
            StartCoroutine("CountingStone");
        }
        else if (gameObject.name == "Plastic")
        {
            StartCoroutine("CountingPlastic");
        }
        else if (gameObject.name == "Copper")
        {
            StartCoroutine("CountingCopper");
        }
        else if (gameObject.name == "Rubber")
        {
            StartCoroutine("CountingRubber");
        }
    }

    IEnumerator CountingWood()
    {
        yield return new WaitForSecondsRealtime(destroy);
        pickCount.countWood++;
    }

    IEnumerator CountingStone()
    {
        yield return new WaitForSecondsRealtime(destroy);
        pickCount.countStone++;
    }

    IEnumerator CountingPlastic()
    {
        yield return new WaitForSecondsRealtime(destroy);
        pickCount.countPlastic++;
    }

    IEnumerator CountingCopper()
    {
        yield return new WaitForSecondsRealtime(destroy);
        pickCount.countCopper++;
    }

    IEnumerator CountingRubber()
    {
        yield return new WaitForSecondsRealtime(destroy);
        pickCount.countRubber++;
    }
    #endregion
}
