using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && GameVariables.keyCount>0)
        {
            GameVariables.keyCount--;
            Destroy(gameObject);

            //uncomment this line for final build
            //Application.Quit();

            //comment out this line for final build
            UnityEditor.EditorApplication.isPlaying = false;

            Debug.Log("We Quit!");
        }
    }
}
