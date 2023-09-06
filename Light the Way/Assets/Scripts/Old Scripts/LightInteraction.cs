using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteraction : MonoBehaviour
{
    public Light lightToCheck; // the light asset to check the color of
    public string requiredColorName; // the name of the required color for the light asset
    public string interactableObjectTag; // the tag of the interactable object
    public string shaderName; // the name of the shader to apply
    public Color shaderColor; // the color to apply to the shader

    private Renderer interactableRenderer; // the renderer of the current interactable object

    void Start()
    {
        interactableRenderer = null;
    }

    void Update()
    {
        // Check if the light color is the desired color
        if (lightToCheck != null && lightToCheck.color == GetRequiredColor())
        {
            // Make sure the interactable object is still in the light
            if (interactableRenderer == null || !interactableRenderer.isVisible)
            {
                interactableRenderer = null;

                // Find the interactable object in the light
                Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
                foreach (Collider hitCollider in hitColliders)
                {
                    if (hitCollider.CompareTag(interactableObjectTag))
                    {
                        interactableRenderer = hitCollider.GetComponent<Renderer>();
                        break;
                    }
                }
            }

            // If an interactable object is in the light, make it interactable and change its shader
            if (interactableRenderer != null)
            {
                interactableRenderer.GetComponent<Collider>().enabled = true;
                interactableRenderer.material.shader = Shader.Find(shaderName);
                interactableRenderer.material.SetColor("_SpecColor", shaderColor);
            }
        }
        else
        {
            // If an interactable object was being affected by the light, make it non-interactable and reset its shader
            if (interactableRenderer != null)
            {
                interactableRenderer.GetComponent<Collider>().enabled = false;
                interactableRenderer.material.shader = Shader.Find("Standard");
                interactableRenderer.material.SetColor("_SpecColor", Color.black);
                interactableRenderer = null;
            }
        }
    }

    private Color GetRequiredColor()
    {
        // Convert the name of the required color to a Color object
        switch (requiredColorName.ToLower())
        {
            case "red":
                return Color.red;
            case "green":
                return Color.green;
            case "blue":
                return Color.blue;
            case "yellow":
                return Color.yellow;
            case "cyan":
                return Color.cyan;
            case "magenta":
                return Color.magenta;
            case "white":
                return Color.white;
            case "black":
                return Color.black;
            default:
                return Color.clear;
        }
    }
}




