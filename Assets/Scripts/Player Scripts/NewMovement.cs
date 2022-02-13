using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMovement : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;

    public float playerSpeed;
    private Vector3 movePlayer;

    public CharacterController player;
    private Vector3 playerInput;

    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;

    public Joystick joystick;
    private Animator playerA;

    private MenuActive isWeaponReady;

    private CharacterAnimation animationScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        animationScript = GetComponent<CharacterAnimation>();
        playerA = GetComponent<Animator>();
        isWeaponReady = GameObject.Find("Weapon1").GetComponent<MenuActive>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;

        playerInput = new Vector3(horizontalMove, 0f, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        player.transform.LookAt(player.transform.position + movePlayer);

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        walkAnimation();

        player.Move(movePlayer * playerSpeed * Time.deltaTime);
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void walkAnimation()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            playerA.SetBool("Movement", true);
        }
        else
        {
            playerA.SetBool("Movement", false);
        }

        if(joystick.Horizontal > 0.40|| joystick.Vertical > 0.40 || joystick.Horizontal < -0.40 || joystick.Vertical < -0.40)
        {
            if (!isWeaponReady.IsWeaponActive)
            {
                playerA.SetBool("run", true);
                playerA.SetBool("runWeapon", false);
            }
            else if(isWeaponReady.IsWeaponActive)
            {
                playerA.SetBool("runWeapon", true);
                playerA.SetBool("run", false);
            }
            
            playerSpeed = 3.5f;
        }
        else
        {
            playerA.SetBool("run", false);
            playerA.SetBool("runWeapon", false);
            playerSpeed = 2.5f;
        }
    }
}
