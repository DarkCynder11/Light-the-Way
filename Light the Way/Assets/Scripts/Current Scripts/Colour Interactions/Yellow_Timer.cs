using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Timer : MonoBehaviour, IInteractable
{
    public ColourSystem m_colourSystem;
    Renderer renderer;
    float timer;
    public Material inactiveMaterial, activeMaterial;
    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Yellow);
        renderer = GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        timer = 5f;
        renderer.material = activeMaterial;
        Debug.Log("interacted");
        IlluminateObject();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
    }

    private void IlluminateObject()
    {

    }
    public ColourSystem.LightColour GetColour()
    {
        return m_colourSystem.GetColour();
    }
}
