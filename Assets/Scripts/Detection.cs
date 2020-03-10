using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Detection : MonoBehaviour
{
    // Adjust the speed for the application.
    private Transform target;
    public float chaseSpeed = 3f;

    public float patrolSpeed = 0.05f;
    //private Vector3 speedRot = Vector3.right * 50f;
    private bool isHidden;

    public Transform pointA;
    public Transform pointB;
    public bool isRight = true;

    private Vector3 pointAPosition;
    private Vector3 pointBPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isHidden = true;
        pointAPosition = new Vector3(pointA.position.z, 0, 0);
        pointBPosition = new Vector3(pointB.position.z, 0, 0);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHidden = false;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHidden = true;
        }
    }

    void Update()
    {
        if (!isHidden)
        {
            
            //transform.Rotate(speedRot * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 thisPosition = new Vector3(transform.position.z, 0, 0);
            if (isRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, patrolSpeed);
                if (thisPosition.Equals(pointBPosition))
                {
                    //Debug.Log ("Position a");
                    isRight = false;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, patrolSpeed);
                if (thisPosition.Equals(pointAPosition))
                {
                    //Debug.Log ("Position b");
                    isRight = true;
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
        }

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}