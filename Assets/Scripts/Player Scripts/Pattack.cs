using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Combos
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
}

public class Pattack : MonoBehaviour
{
    Animator player_Anim;
    private MenuActive weapon1Button;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private Combos current_Combo_State;

    public float playerAttackDamage;
    public float increasedDamage;

    public AudioClip batPunch;
    public AudioClip crowbarPunch;
    public AudioClip crowbarPunch2;
    public AudioClip katanaPunch1;
    public AudioClip katanaPunch2;
    public AudioClip katanaPunch3;

    void Start()
    {
        player_Anim = GetComponent<Animator>();

        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = Combos.NONE;
    }


    void Update()
    {
        

        if(MyUtils.FindInChildrenIncludingInactive(gameObject, "w_katana").activeInHierarchy)
        {
            ComboAttacks();
            ResetCombos();
        }
        else if(MyUtils.FindInChildrenIncludingInactive(gameObject, "w_baseballbat").activeInHierarchy)
        {
            if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M))
            {
                player_Anim.SetTrigger("Bat_Punch");
            }
        }
        else if(MyUtils.FindInChildrenIncludingInactive(gameObject, "w_crowbar").activeInHierarchy)
        {
            ComboAttacksCrowbar();
            ResetCombos();
        }

    }

    void ComboAttacks()
    {
        StartCoroutine(attackCombos());
    }

    void ComboAttacksCrowbar()
    {
        StartCoroutine(attackCombosCrowbar());
    }

    IEnumerator attackCombos()
    {
        if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M) && GameObject.FindGameObjectWithTag("Katana") != null)
        {

            if (current_Combo_State == Combos.PUNCH_3)
                yield break;

            yield return new WaitForSeconds(player_Anim.GetCurrentAnimatorStateInfo(1).length - 1f);

            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == Combos.PUNCH_1)
            {
                player_Anim.SetTrigger("Punch1");
            }

            if (current_Combo_State == Combos.PUNCH_2)
            {
                player_Anim.SetTrigger("Punch2");
            }

            if (current_Combo_State == Combos.PUNCH_3)
            {
                player_Anim.SetTrigger("Punch3");
            }

        }
    }

    IEnumerator attackCombosCrowbar()
    {
        if (Input.GetButtonDownMobile("Fire1") || Input.GetKeyDown(KeyCode.M) && GameObject.FindGameObjectWithTag("Crowbar") != null)
        {

            if (current_Combo_State == Combos.PUNCH_2)
                yield break;

            yield return new WaitForSeconds(player_Anim.GetCurrentAnimatorStateInfo(1).length - 1f);

            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == Combos.PUNCH_1)
            {
                player_Anim.SetTrigger("Crowbar_Punch");
            }

            if (current_Combo_State == Combos.PUNCH_2)
            {
                player_Anim.SetTrigger("Crowbar_Punch2");
            }

        }
    }

    void ResetCombos()
    {

        if (activateTimerToReset)
        {

            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {

                current_Combo_State = Combos.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;

            }

        }

    }

    public void PlayBatPunch()
    {
        GetComponent<AudioSource>().PlayOneShot(batPunch);
    }

    public void PlayCrowBarPunch()
    {
        GetComponent<AudioSource>().PlayOneShot(crowbarPunch);
    }

    public void PlayCrowBarSecondPunch()
    {
        GetComponent<AudioSource>().PlayOneShot(crowbarPunch2);
    }

    public void PlayKatanaPunch1()
    {
        GetComponent<AudioSource>().PlayOneShot(katanaPunch1);
    }

    public void PlayKatanaPunch2()
    {
        GetComponent<AudioSource>().PlayOneShot(katanaPunch2);
    }

    public void PlayKatanaPunch3()
    {
        GetComponent<AudioSource>().PlayOneShot(katanaPunch3);
    }

}
