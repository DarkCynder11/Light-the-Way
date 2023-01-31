using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            print("shows blue object");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            print("interactable");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Blue")
        {
            print("changes back to gray");
        }
    }
}
