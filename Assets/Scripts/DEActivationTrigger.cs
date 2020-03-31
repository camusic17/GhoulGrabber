using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEActivationTrigger : MonoBehaviour {

    [SerializeField] private GameObject displayed;
    void Start()
    {
        displayed.SetActive(true);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayed.SetActive(true);
        }
    }
}
