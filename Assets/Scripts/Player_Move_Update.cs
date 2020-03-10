using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Update : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;

    [Tooltip("Only change this if your character is having problems jumping when they shouldn't or not jumping at all.")]
    public float distToGround = 1.0f;
    private bool inControl = true;

    [Tooltip("Everything you jump on should be put in a ground layer. Without this, your player probably* is able to jump infinitely")]
    public LayerMask GroundLayer;





    // Update is called once per frame
    void Update()
    {
        if (inControl)
        {
            PlayerMove();
        }
        
    }

    void PlayerMove()
    {
        //CONTROLS
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        /*
        //ANIMATIONS
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        */
        
        //PHYSICS
        gameObject.GetComponent<Rigidbody>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
        GetComponent<Rigidbody>().AddForce(Vector3.up * playerJumpPower);

    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + GroundLayer);

        //if (hit.collider != null)
        //{
        //    return true;
        //}
        //return false;

    }

    public void SetControl(bool b)
    {
        inControl = b;
    }
}
