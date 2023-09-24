using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Walk : MonoBehaviour, IInteractable
{
    public ColourSystem m_colourSystem;
    private new Renderer renderer;
    public Material inactiveMaterial, activeMaterial;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Green);
        renderer ??= GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }
    public void Collision()
    {
        //GetComponent<Renderer>().material = activeMaterial;
    }

    public ColourSystem.LightColour GetColour()
    {
        return m_colourSystem.GetColour();
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        renderer.material = activeMaterial;
        Debug.Log("interacted");
        //TeleportPlayer(); walk method will go here.
    }

}
