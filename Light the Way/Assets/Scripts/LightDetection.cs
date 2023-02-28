using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    public Light colourLight;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blue" && colourLight.color == Color.blue)
        {
            print("shows blue object");
        }
        else if (other.gameObject.tag == "Green" && colourLight.color == Color.green)
        {
            print("shows green object");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Blue" && colourLight.color == Color.blue)
        {
            print("interactable");
        }
        else if (other.gameObject.tag == "Green" && colourLight.color == Color.green)
        {
            print("interactable");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Blue" && colourLight.color == Color.blue)
        {
            print("changes back to gray");
        }
        else if (other.gameObject.tag == "Green" && colourLight.color == Color.green)
        {
            print("changes back to gray");
        }

    }
}
