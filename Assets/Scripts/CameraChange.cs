//Sam Bevans-Kerr//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int camMode;
    public bool isFirst = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            Debug.Log("Camera Changed!");
            if (camMode == 1)
            {
                camMode = 0;
                isFirst = true;
            }
            else
            {
                camMode += 1;
                isFirst = false;
            }
            StartCoroutine(CamChange() );
        }
    }
    IEnumerator CamChange()
    {
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0) {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);
          
            }
        if(camMode == 1)
        {
            FirstCam.SetActive(true);
            ThirdCam.SetActive(false);

        }
    }
}
