using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
//Moves object between two points
public class PatrolY_3D : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    [SerializeField] public GameObject pointA;
    [SerializeField] public GameObject pointB;
    [SerializeField] private bool reverseMove = false;
    [SerializeField] private Transform objectToUse;
    [SerializeField] private bool moveThisObject = false;
    private float startTime;
    private float journeyLength;
    private float distCovered;
    private float fracJourney;
    void Start()
    {
        startTime = Time.time;
        if (moveThisObject)
        {
            objectToUse = transform;
        }
        journeyLength = Vector3.Distance(pointA.transform.position, pointB.transform.position);
    }
    void Update()
    {
        distCovered = (Time.time - startTime) * moveSpeed;
        fracJourney = distCovered / journeyLength;
        if (reverseMove)
        {
            objectToUse.position = Vector3.Lerp(pointB.transform.position, pointA.transform.position, fracJourney);
        }
        else
        {
            objectToUse.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, fracJourney);
        }
        if ((Vector3.Distance(objectToUse.position, pointB.transform.position) == 0.0f || Vector3.Distance(objectToUse.position, pointA.transform.position) == 0.0f)) //Checks if the object has travelled to one of the points
        {
            if (reverseMove)
            {
                reverseMove = false;
            }
            else
            {
                reverseMove = true;
            }
            startTime = Time.time;
        }
    }
}