using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Stay : MonoBehaviour, IInteractable
{
    public ColourSystem m_colourSystem;
    private new Renderer renderer;
    public Material inactiveMaterial, activeMaterial;
    public GameObject lanLight;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Yellow);
        renderer ??= GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
        lanLight.SetActive(false);
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        renderer.material = activeMaterial;
        LightOn();
    }

    private void LightOn()
    {
        lanLight.SetActive(true);
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
