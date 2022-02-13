using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI_Navigation : MonoBehaviour
{

    private NavMeshAgent agent;
    public Transform playerTrans;
    private Animator npcAnim;
    private BoxCollider boxCollider;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigidbody;

    private int currentWP = 0;
    public float accuracy = 3.0f;

    private float patrolRadius = 30f;
    private float patrol_Timer = 10f;
    private float timer_Count;
    public float newEXP;
    public float rotationSpeed;
    public float distance;
    public float distanceToPlayer = 2.5f;

    public float speed = 3.0f;
    public float angularSpeed = 250f;
    public float acceleration = 5f;

    public float attackDamage = 5f;
    public float stunTime = 1.0f;

    public bool onPanic = false;
    public bool isDeath = false;

    public List<AudioClip> zombieScreams;
    public AudioClip zombiePunched;
    public AudioClip zombieDeath;

    HealthScript impact;
    ExpManager savedEXP;

    string[] deaths = {"Death", "DeathB", "DeathC"};
    int index;
    string currentDeath;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        npcAnim = GetComponent<Animator>();
        impact = GetComponent<HealthScript>();
        boxCollider = GetComponent<BoxCollider>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rigidbody = GetComponent<Rigidbody>();
        savedEXP = GameObject.Find("ExpPoints").GetComponent<ExpManager>();

        timer_Count = patrol_Timer;
        newEXP = 0;

        index = Random.Range(0, deaths.Length);
        currentDeath = deaths[index];

        onPanic = true;
        npcAnim.SetTrigger("Panic");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            Patrol();
        }
        
        CheckHealth();

        if (onPanic && !isDeath)
        {
            boxCollider.enabled = false;
            Patrol();
            OnAttack();
        }
    }

    void Patrol()
    {
        if (!isDeath)
        {
            timer_Count += Time.deltaTime;

            if (timer_Count > patrol_Timer && !onPanic)
            {
                SetNewRandomDestination();
                timer_Count = 0;
            }

            if (onPanic)
            {
                agent.speed = speed;
                agent.angularSpeed = angularSpeed;
                agent.acceleration = acceleration;


                if (agent.velocity.sqrMagnitude == 0)
                {
                    npcAnim.SetBool("Movement", false);
                }
                else
                {
                    npcAnim.SetBool("Walk", true);
                    npcAnim.SetBool("Movement", true);
                }
            }
            /*else
            {
                if (agent.velocity.sqrMagnitude == 0)
                {
                    npcAnim.SetBool("Walk", false);
                }
                else
                {
                    npcAnim.SetBool("Walk", true);
                }
            }*/
        }
        
        
    }

    void OnAttack()
    {
        if (agent.isOnNavMesh && playerTrans != null)
        {
            distance = Vector3.Distance(transform.position, playerTrans.position);
            agent.SetDestination(playerTrans.position);

            if (distance < distanceToPlayer)
            {
                agent.isStopped = true;
                npcAnim.SetBool("Punch", true);
                RotateTowards(playerTrans);
            }
            else if (distance > distanceToPlayer)
            {
                npcAnim.SetBool("Punch", false);
                agent.isStopped = false;
            }
        }
        else
        {
            return;
        }
        
    }

    void RotateTowards(Transform target)
    {
        if (agent.navMeshOwner != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            return;
        }
        
    }

    void SetNewRandomDestination()
    {
        Vector3 newDestination = RandomNavSphere(transform.position, patrolRadius, -1);
        if (agent.navMeshOwner != null)
        {
            agent.SetDestination(newDestination);
        }
        else
        {
            return;
        }
        
    }

    Vector3 RandomNavSphere(Vector3 originPos, float radius, int layerMask)
    {
        Vector3 ranDir = Random.insideUnitSphere * radius;
        ranDir += originPos;
        NavMeshHit navHit;
        NavMesh.SamplePosition(ranDir, out navHit, radius, layerMask);
        return navHit.position;
    }

    private void OnTriggerEnter(Collider target)
    {
        if (!isDeath)
        {
            /*if (target.tag == "Player" && !onPanic)
            {
                onPanic = true;
                npcAnim.SetTrigger("Panic");
            }*/
        }

        if (target.tag == "Bat" && onPanic && !isDeath)
        {
            npcAnim.SetTrigger("Hit");
            impact.ApplyDamage((playerTrans.GetComponent<Pattack>().playerAttackDamage + playerTrans.GetComponent<Pattack>().increasedDamage), false);
            /*newEXP += 5;
            savedEXP.points += newEXP;*/
            StartCoroutine("Stunned");
            //activar animacion mareado
        }

        if (target.tag == "Katana" && onPanic && !isDeath)
        {
            npcAnim.SetTrigger("Hit");
            impact.ApplyDamage((playerTrans.GetComponent<Pattack>().playerAttackDamage + playerTrans.GetComponent<Pattack>().playerAttackDamage), false);
            /*newEXP += 5;
            savedEXP.points += newEXP;*/
            StartCoroutine("Stunned");
            //activar animacion mareado
        }

        if (target.tag == "Crowbar" && onPanic && !isDeath)
        {
            npcAnim.SetTrigger("Hit");
            impact.ApplyDamage((playerTrans.GetComponent<Pattack>().playerAttackDamage + playerTrans.GetComponent<Pattack>().playerAttackDamage), false);
            /*newEXP += 5;
            savedEXP.points += newEXP;*/
            StartCoroutine("Stunned");
            //activar animacion mareado
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if(player.name == "Cone" && player.GetType() == typeof(MeshCollider))
        {
            if (isDeath)
            {
                gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
        }
    }

    IEnumerator Stunned()
    {
        if(agent.navMeshOwner != null)
        {
            agent.isStopped = true;
            yield return new WaitForSecondsRealtime(stunTime);
            agent.isStopped = false;
        }
        else
        {
            yield return null;
        }
            
    }

    void CheckHealth()
    {
        if(impact.health <= 0 && !isDeath)
        {
            isDeath = true;
            /*rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<CapsuleCollider>().isTrigger = false;*/
            rigidbody.isKinematic = true;
            //agent.enabled = false;
            /*agent.isStopped = true;
            agent.velocity = Vector3.zero;*/
            npcAnim.SetBool("Punch", false);
            npcAnim.SetTrigger("Stop");
            onPanic = false;
            npcAnim.SetTrigger(currentDeath);
            //agent.enabled = false;
            //StartCoroutine(AfterDeath());
            transform.Find("MinimapIcon").gameObject.SetActive(false);
            newEXP += 15f;
            savedEXP.points += newEXP;
        }
    }

    public void GunAttack(float damage)
    {
        npcAnim.SetTrigger("Hit");
        impact.ApplyDamage(damage, false);
        /*newEXP += 0.5f;
        savedEXP.points += newEXP;*/
        StartCoroutine("Stunned");
    }

    IEnumerator AfterDeath()
    {
        yield return new WaitForSeconds(0.35f);
        //npcAnim.enabled = false;
        newEXP += 15f;
        savedEXP.points += newEXP;
        transform.Find("Health").gameObject.SetActive(false);
        transform.Find("MinimapIcon").gameObject.SetActive(false);
        yield break;
        //Destroy(GetComponent<AI_Navigation>());
        //capsuleCollider.enabled = false;
        //rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    IEnumerator DeleteEnemy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<NavMeshAgent>().baseOffset = -2f;
        yield break;
    }

    public void DeathAnimationComplete()
    {
        agent.baseOffset = -2f;
    }

    public void ZombieAttackSound()
    {
        GetComponent<AudioSource>().PlayOneShot(zombieScreams[Random.Range(0, 3)]);
    }

    public void ZombiePunchedSound()
    {
        GetComponent<AudioSource>().PlayOneShot(zombiePunched);
    }

    public void ZombieDeathSound()
    {
        GetComponent<AudioSource>().PlayOneShot(zombieDeath);
    }

}
