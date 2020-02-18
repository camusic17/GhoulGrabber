using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEy : MonoBehaviour
{

     void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            GameVariables.keyCount += 1;

            //DEAN'S CODE-
            GameVariables.keyPickedUp = true;
            //-----

            Destroy(gameObject);
        }
    }

}
