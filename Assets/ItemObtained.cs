//Built by Dean Banh

//Concept for disappearing GUI taken from:
//https://answers.unity.com/questions/970467/how-to-make-disappear-a-gui-text-after-an-amount-o.html

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObtained : MonoBehaviour
{

  public Text obtainedText;  // public if you want to drag your text object in there manually
  public bool obtMSG;

    // Start is called before the first frame update
    void Start()
    {

      obtainedText = GetComponent<Text>();

      bool obtMSG = false;

    }

    // Update is called once per frame
    void Update()
    {

      if (GameVariables.keyPickedUp == true){

        obtMSG = true;

        obtainedText.text = "Key obtained!!!";

      }

      if (obtMSG == true){

        Destroy(gameObject, 3);

      }

    }
}
