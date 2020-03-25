using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flash : MonoBehaviour
{
    //public so we can edit in the editor
    public float flashTimelength = .2f;

    private Image flashImage;
    private float startTime;
    private bool flashing = false;
    public bool b;



    void Start()
    {
        //get flash image
        flashImage = GetComponent<Image>();

        //change alpha value of image to 0 before the first frame
        Color col = flashImage.color;
        col.a = 0.0f;
        flashImage.color = col;

        
}

    void Update()
    {
        //if primary mouse button is clicked and we are not flashing
        b = GameObject.Find("Image").GetComponent<CameraChange>().isFirst;
        if (Input.GetMouseButtonDown(0) && !flashing && b)
        {
            //flash the camera
            doFlash();
        }
    }

    public void doFlash()
    {
        //initial color
        Color col = flashImage.color;

        //save start time for fade effect
        startTime = Time.time;

        //change alpha to 1 to make screen flash the image
        col.a = 1.0f;
        flashImage.color = col;

        //flag we are flashing so user can't do 2 of them
        flashing = true;

        //start coroutine that makes the flash fade
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

            //point at which execution will pause and be resumed the following frame
            yield return null;
        }

        //allows player to now flash the camera again
        flashing = false;

        yield break;
    }
}
