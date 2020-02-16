using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Detection : MonoBehaviour
{
    // Adjust the speed for the application.
    private Transform target;
    private float speed = 3f;
    private Vector3 speedRot = Vector3.right * 50f;
    private bool isHidden;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isHidden = true;
    }

    private void OnTriggerEnter(Collider collision)
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
            transform.Rotate(speedRot * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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