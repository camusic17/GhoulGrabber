﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    // Attach this to your checkpoints. Checkpoints should have a collider set to trigger.
    // If you want to make a sprite animate on activating the checkpoint, let me know! It shouldn't be too hard to program.
    private GameObject respawn;
    private bool activated = false;
	
	void Start () {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (!activated)
        {
            if (collision.CompareTag("Player"))
            {
                respawn.transform.position = transform.position;
            }
        }
    }

}