using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Walk : MonoBehaviour, IInteractable
{
    public void Collision()
    {
        //GetComponent<Renderer>().material = activeMaterial;
    }

    public ColourSystem.LightColour GetColour()
    {
        throw new System.NotImplementedException();
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        Debug.Log("water was interacted with");
    }

    public void Setup()
    {

    }
}
