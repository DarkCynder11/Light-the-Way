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
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Blue);
        renderer ??= GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }
    public void Collision()
    {
        renderer.material = activeMaterial;
        GetComponent<BoxCollider>().isTrigger = false;
        Debug.Log("Collided");
    }

    public ColourSystem.LightColour GetColour()
    {
        return m_colourSystem.GetColour();
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        Debug.Log("No Interaction");
    }
    public void Revert()
    {
        renderer.material = inactiveMaterial;
        GetComponent<BoxCollider>().isTrigger = true;
    }

}
