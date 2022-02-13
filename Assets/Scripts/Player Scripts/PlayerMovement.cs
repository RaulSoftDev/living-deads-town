using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterAnimation player_Anim;
    private Rigidbody myBody;

    public float walk_Speed = 2f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;

    public Joystick joystick;

    // Start is called before the first frame update
    void Awake() {
        myBody = GetComponent<Rigidbody>();
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Update is called once per frame
    void Update() {
        //RotatePlayer
        AnimatePlayerWalk();
    }

    void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement() {

        myBody.velocity = new Vector3(
            joystick.Horizontal * (-walk_Speed),
            myBody.velocity.y,
            joystick.Vertical * (-z_Speed));

    } // movement

    void RotatePlayer() { 

        if(joystick.Horizontal > 0) {

            transform.rotation = Quaternion.Euler(0f, 0f, rotation_Y);

        } else if(joystick.Horizontal < 0) {

            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Abs(rotation_Y));

        }

    } // rotation

    void AnimatePlayerWalk() { 
    
        if(joystick.Horizontal != 0 ||
                joystick.Vertical != 0) {

            player_Anim.Walk(true);
    
        } else {
            player_Anim.Walk(false);
        }

    } // animate player walk

} // class






































