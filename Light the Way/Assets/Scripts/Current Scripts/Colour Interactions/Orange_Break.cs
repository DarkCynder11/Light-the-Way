using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange_Break : MonoBehaviour, IInteractable
{
    public ColourSystem m_colourSystem;
    private new Renderer renderer;
    public Material inactiveMaterial, activeMaterial;
    //public GameObject brickBreak;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Orange);
        renderer ??= GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
        //brickBreak.SetActive(true);
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        renderer.material = activeMaterial;
        Debug.Log("interacted");
        BreakStone();
    }
    private void BreakStone()
    {
        //brickBreak.SetActive(false);
        Destroy(gameObject);
    }

    public ColourSystem.LightColour GetColour()
    {
        return m_colourSystem.GetColour();
    }

    public void Collision()
    {
        renderer.material = activeMaterial;
    }

    public void Revert()
    {
        renderer.material = inactiveMaterial;
    }
}
