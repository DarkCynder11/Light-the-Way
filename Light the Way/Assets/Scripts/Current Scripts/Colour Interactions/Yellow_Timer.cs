using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_Timer : MonoBehaviour, IInteractable
{
    public ColourSystem m_colourSystem;
    private new Renderer renderer;
    float timer;
    public Material inactiveMaterial, activeMaterial;
    public GameObject lanLit;

    private bool timerOn = false;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Yellow);
        renderer ??= GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
        lanLit.SetActive(false);
    }

    public void Interact(ColourSystem.LightColour playerColour)
    {
        timer = 10f;
        renderer.material = activeMaterial;
        IlluminateObject();
        timerOn = true;
        GetComponentInParent<LightPuzzle>().UpdateCount(1, gameObject.name);
        Debug.Log("update count");
        
    }
    private void Update()
    {
        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                lanLit.SetActive(false);
                timerOn = false;
                renderer.material = inactiveMaterial;
                GetComponentInParent<LightPuzzle>().UpdateCount(-1, gameObject.name);
            }
        }
        
    }

    private void IlluminateObject()
    {
        lanLit.SetActive(true);
        //get a reference to the holder for lanterns
        
        
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
