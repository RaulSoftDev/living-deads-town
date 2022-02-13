using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMovement : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public float rotationSpeed = 0.15f;

    public Joystick joystickController;
    private Animator playerAnimator;

    private MenuActive isWeaponReady;
    private CharacterController controller;
    private Rigidbody rigidbody;

    public float moveAxis;
    public float moveAxisHorizontal;

    public bool isInverted;

    public AudioClip gunSound;
    public AudioClip gunShootSound;
    public AudioClip rifleSound;

    public AudioClip step1;
    public AudioClip step2;

    public AudioClip deathYell;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInverted)
        {
            moveAxis = joystickController.Vertical;
            moveAxisHorizontal = joystickController.Horizontal;
        }
        else
        {
            moveAxis = joystickController.Vertical * -1;
            moveAxisHorizontal = joystickController.Horizontal * -1;
        }
        

        //JoystickBreak();

        walkAnimation();
        //Move(moveAxis, moveAxisHorizontal);
        Turn(moveAxis, moveAxisHorizontal);
        MoveTest();
    }

    void MoveTest()
    {
        controller.SimpleMove(Vector3.forward * moveAxis * moveSpeed);
        controller.SimpleMove(Vector3.right * moveAxisHorizontal * moveSpeed);

    }

    void ApplyInput(float moveInput, float turnInput)
    {
        //Move(moveInput);
        //Turn(turnInput);
    }

    void Move(float inputV, float inputH)
    {
        transform.Translate(Vector3.ClampMagnitude(Vector3.forward, 1.0f) * inputV * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.ClampMagnitude(Vector3.right, 1.0f) * inputH * moveSpeed * Time.deltaTime, Space.World);
    }

    void Turn(float inputV, float inputH)
    {
        Vector3 movement = new Vector3(inputH, 0.0f, inputV);

        if(movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed);
        }
    }

    void walkAnimation()
    {
        if (joystickController.Horizontal != 0 || joystickController.Vertical != 0)
        {
            playerAnimator.SetBool("Movement", true);
        }
        else
        {
            playerAnimator.SetBool("Movement", false);
        }

        if (joystickController.Horizontal > 0.29 || joystickController.Vertical > 0.29 || joystickController.Horizontal < -0.29 || joystickController.Vertical < -0.29)
        {
                playerAnimator.SetBool("runWeapon", true);
                playerAnimator.SetBool("run", false);

        }
        else
        {
            playerAnimator.SetBool("run", false);
            playerAnimator.SetBool("runWeapon", false);
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        //Enemy attack value and punch collider
        if(enemy.tag == "Punch")
        {
            HealthScript damageOnAttack = GetComponent<HealthScript>();
            damageOnAttack.ApplyDamage(enemy.transform.parent.parent.parent.parent.parent.parent.parent.parent.GetComponent<AI_Navigation>().attackDamage, false);
        }
    }

    void JoystickBreak()
    {
       if(moveAxis > 0.45)
        {
            joystickController.SnapY = true;
        }
       else if(moveAxis < 0.45 && moveAxis < -0.45)
        {
            joystickController.SnapY = false;
        }

       if(moveAxis > -0.45)
        {
            joystickController.SnapY = true;
        }
       else if(moveAxis < -0.45 && moveAxis < 0.45)
        {
            joystickController.SnapY = false;
        }
    }

    public void GunAudioSound()
    {
        GetComponent<AudioSource>().PlayOneShot(gunSound);
    }

    public void GunShootSound()
    {
        GetComponent<AudioSource>().PlayOneShot(gunShootSound);
    }

    public void RifleShootSound()
    {
        GetComponent<AudioSource>().PlayOneShot(rifleSound);
    }

    public void AudioStep1()
    {
        GetComponent<AudioSource>().PlayOneShot(step1);
    }

    public void AudioStep2()
    {
        GetComponent<AudioSource>().PlayOneShot(step2);
    }

    public void DeathSound()
    {
        GetComponent<AudioSource>().PlayOneShot(deathYell);
    }
}
