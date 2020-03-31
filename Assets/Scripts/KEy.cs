using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KEy : MonoBehaviour
{
    public GameObject key; // actual key
    public GameObject FirstKey; // UI elements
    public GameObject SecondKey;
    public GameObject ThirdKey;

    // Start is called before the first frame update
    void Start()
    {

        FirstKey.SetActive(false);
        SecondKey.SetActive(false);
        ThirdKey.SetActive(false);

    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            GameVariables.keyCount += 1;

            //DEAN'S CODE-
            GameVariables.keyPickedUp = true;
            //-----

            Destroy(key);
            FirstKey.SetActive(true);
        }
    }

}
