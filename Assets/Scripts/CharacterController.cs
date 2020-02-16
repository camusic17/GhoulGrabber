using UnityEngine;
using System.Collections;
using System;

public class CharacterController : MonoBehaviour
{

    public float jumpSpeed = 100.0f;
    private bool onGround = false;

    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    float movementSpeed;
    internal bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        float amountToMove = movementSpeed * Time.deltaTime;
        Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left * amountToMove) + (Input.GetAxis("Vertical") * Vector3.forward * amountToMove);
        rb.AddForce(movement, ForceMode.Force);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }

    void OnCollisionStay()
    {
        onGround = true;
    }
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

    internal void Move(Vector3 vector3)
    {
        throw new NotImplementedException();
    }
}
