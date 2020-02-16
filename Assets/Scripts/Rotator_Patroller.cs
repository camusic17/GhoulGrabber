using UnityEngine;
using System.Collections;

public class Rotator_Patroller : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0, 35, 0) * Time.deltaTime);
    }
}