using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hidden : MonoBehaviour
{

    private Transform target;
    private bool isHidden;

    void Start()
    {
        isHidden = false;

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Cover"))
        {
            isHidden = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Cover"))
        {
            isHidden = false;
        }
    }

    void Update()
    {
        if (isHidden)
        {
            transform.gameObject.tag = "Hidden";
        }
        else
        {
            transform.gameObject.tag = "Player";
        }

    }


}