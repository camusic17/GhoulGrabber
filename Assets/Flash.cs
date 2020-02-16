﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flash : MonoBehaviour
{
    public float flashTimelength = .2f;
    //public bool doCameraFlash = false;

    ///////////////////////////////////////////////////
    private Image flashImage;
    private float startTime;
    private bool flashing = false;
    // Start is called before the first frame update
    void Start()
    {
        flashImage = GetComponent<Image>();
        Color col = flashImage.color;
        col.a = 0.0f;
        flashImage.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !flashing)
        {
            CameraFlash();
        }
    }

    public void CameraFlash()
    {
        // initial color
        Color col = flashImage.color;

        // start time to fade over time
        startTime = Time.time;

        // so we can flash again
       // doCameraFlash = false;

        // start it as alpha = 1.0 (opaque)
        col.a = 1.0f;

        // flash image start color
        flashImage.color = col;

        // flag we are flashing so user can't do 2 of them
        flashing = true;

        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        bool done = false;

        while (!done)
        {
            float perc;
            Color col = flashImage.color;

            perc = Time.time - startTime;
            perc = perc / flashTimelength;

            if (perc > 1.0f)
            {
                perc = 1.0f;
                done = true;
            }

            col.a = Mathf.Lerp(1.0f, 0.0f, perc);
            flashImage.color = col;
            flashing = true;

            yield return null;
        }

        flashing = false;

        yield break;
    }
}
