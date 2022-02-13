using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vision : MonoBehaviour
{
    Animator playerANIM;
    public float gunDamage;
    public float shotGunDamage;
    public float rifleDamage;
    public float ammunition;
    public List<GameObject> targets = new List<GameObject>();
    public Image reload;
    public Button A;
    public Text bullets;
    public bool isGun;
    public bool isShotGun;
    public bool isRifle;
    bool alreadyShoot = false;
    public AudioClip gunSound;
    public GunCallScript gunReadyScript;

    public GameObject shootAreaANIM;
    GameObject[] enemySearch;

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (GameObject potencialTarget in enemies)
        {
            Vector3 directionToTarget = potencialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potencialTarget.transform;
            }
        }
        return bestTarget;
    }

    private void Awake()
    {
        reload.fillAmount = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerANIM = GetComponentInParent<Animator>();

        if (isGun)
        {
            ammunition = 5;
        }

        if (isShotGun)
        {
            ammunition = 1;
        }

        if (isRifle)
        {
            ammunition = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemySearch = GameObject.FindGameObjectsWithTag("Enemy");

        //targets.RemoveAll(null);

        if (isGun)
        {
            GunShoot();
            showAmmo();
        }

        if(isShotGun)
        {
            GunShoot2();
            showAmmo2();
        }

        if (isRifle)
        {
            GunShoot3();
            showAmmo3();
        }
        
        //ReloadingButton();
    }

    private void OnTriggerStay(Collider enemy)
    {
        
    }

    private void OnTriggerEnter(Collider shotgunTarget)
    {
        if (shotgunTarget.tag == "Enemy")
        {
            targets.Add(shotgunTarget.gameObject);
        }

    }

    private void OnTriggerExit(Collider enemy2)
    {
        if(enemy2.tag == "Enemy")
        {
            targets.Remove(enemy2.gameObject);
        }
    }

    void IsEnemyInFrontOf()
    {
        var heading = GameObject.FindGameObjectWithTag("Player").transform.position - GetClosestEnemy(enemySearch).position;
        float dot = Vector3.Dot(heading, GetClosestEnemy(enemySearch).forward);

        RaycastHit hit;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(dot <= -1)
        {
            if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, 20f))
            {
                Debug.DrawRay(player.transform.position, player.transform.forward * hit.distance, Color.yellow);
                GetClosestEnemy(enemySearch).GetComponent<AI_Navigation>().GunAttack(gunDamage);
            }
            
        }
        else
        {
            return;
        }
    }

    void GunShoot()
    {
        if(ammunition > 0 && gunReadyScript.gunReady)
        {
            if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M))
            {
                    StartCoroutine(GunShootTiming());
                    ammunition -= 1;
                    playerANIM.SetBool("Fire", true);
                    alreadyShoot = true;
                    transform.parent.GetComponent<AudioSource>().PlayOneShot(gunSound);
                foreach (GameObject item in targets)
                {
                    if (item != null)
                    {
                        item.GetComponent<AI_Navigation>().GunAttack(gunDamage);
                    }
                    else
                    {
                        return;
                    }

                }
                gunReadyScript.gunReady = false;
                /*foreach (GameObject item in targets)
                {
                    if (item != null)
                    {
                        item.GetComponent<AI_Navigation>().GunAttack(gunDamage);
                    }
                    else
                    {
                        return;
                    }
                   
                }*/
                /*ammunition -= 1;
                StartCoroutine(GunShootTiming());
                playerANIM.SetBool("Fire", true);
                IsEnemyInFrontOf();*/
            }
            else
            {
                playerANIM.SetBool("Fire", false);
            }
        }
        else if (ammunition <= 0)
        {
            reload.fillAmount += 0.03f;

            if(reload.fillAmount == 1)
            {
                ammunition = 5;
                reload.fillAmount = 0;
            }
        }

    }

    IEnumerator GunShootTiming()
    {
        shootAreaANIM.GetComponent<Animator>().SetBool("ShootON", true);
        yield return new WaitForSeconds(0.01f);
        shootAreaANIM.GetComponent<Animator>().SetBool("ShootON", false);
        yield break;
    }

    void GunShoot2()
    {
        if (ammunition > 0)
        {
            if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(GunShootTiming());
                ammunition -= 1;
                playerANIM.SetBool("Fire", true);
                transform.parent.GetComponent<AudioSource>().PlayOneShot(gunSound);
                foreach (GameObject item in targets)
                {
                    if(item != null)
                    {
                        item.GetComponent<AI_Navigation>().GunAttack(shotGunDamage);
                    }
                    else
                    {
                        return;
                    }
                    
                }
                gunReadyScript.gunReady = false;
            }
            else
            {
                playerANIM.SetBool("Fire", false);
            }
        }
        else if (ammunition <= 0)
        {
            reload.fillAmount += 0.03f;

            if (reload.fillAmount == 1)
            {
                ammunition = 1;
                reload.fillAmount = 0;
            }
        }

    }

    void GunShoot3()
    {
        if (ammunition > 0)
        {
            if (Input.GetButtonMobile("Fire1") || Input.GetKey(KeyCode.M))
            {
                StartCoroutine(GunShootTiming());
                ammunition -= 1;
                playerANIM.SetBool("AutomaticFire", true);
                foreach (GameObject item in targets)
                {
                    item.GetComponent<AI_Navigation>().GunAttack(rifleDamage);
                }
            }
            else
            {
                playerANIM.SetBool("AutomaticFire", false);
            }
        }
        else if (ammunition <= 0)
        {
            reload.fillAmount += 0.03f;

            if (reload.fillAmount == 1)
            {
                ammunition = 20;
                reload.fillAmount = 0;
            }
        }

    }

    void showAmmo()
    {
        bullets.text = +ammunition+"/5";
    }

    void showAmmo2()
    {
        bullets.text = +ammunition+ "/1";
    }

    void showAmmo3()
    {
        bullets.text = +ammunition + "/20";
    }

    void ReloadingButton()
    {
        if (Input.GetButtonDownMobile("Fire2"))
        {
            reload.fillAmount += 0.03f;

            if (reload.fillAmount == 1)
            {
                ammunition = 5;
                reload.fillAmount = 0;
            }
        }
        
    }
}
