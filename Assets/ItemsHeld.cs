//Built by Dean Banh

//Structure of script for displaying variables in UI taken from:
// /https://forum.unity.com/threads/how-to-display-a-variable-value-on-screen.282725/

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsHeld : MonoBehaviour
{

  public Text keyText;  // public if you want to drag your text object in there manually

    // Start is called before the first frame update
    void Start()
    {

      keyText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {

      if (GameVariables.keyCount == 0){

        keyText.text = "Items held:";

      }

      else {

        keyText.text = "Items held: key x" + GameVariables.keyCount.ToString();

      }

    }
}
