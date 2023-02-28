using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteraction : MonoBehaviour
{
    public Light lightToCheck; // the light asset to check the color of
    public GameObject interactableObject; // the tagged object to make interactable
    public string shaderName; // the name of the shader to apply
    public Color shaderColor; // the color to apply to the shader

    private Renderer interactableRenderer; // the renderer of the interactable object

    void Start()
    {
        interactableRenderer = interactableObject.GetComponent<Renderer>();
    }

    void Update()
    {
        // Check if the light color is the desired color
        if (lightToCheck.color == Color.green)
        {
            // Make the interactable object interactable
            interactableObject.GetComponent<Collider>().enabled = true;

            // Change the shader of the interactable object
            interactableRenderer.material.shader = Shader.Find(shaderName);
            interactableRenderer.material.SetColor("_SpecColor", shaderColor);
        }
    }
}



