using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Walk : MonoBehaviour, IInteractable
{
    public ColourSystem.LightColour GetColour()
    {
        throw new System.NotImplementedException();
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        Debug.Log("water was interacted with");
    }
}
