using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public ColorTagPair[] colorTagPairs;
    public Material nonInteractableMaterial;

    private Color currentColor;

    void OnTriggerEnter(Collider other)
    {
        foreach (ColorTagPair colorTagPair in colorTagPairs)
        {
            if (other.CompareTag(colorTagPair.tag) && colorTagPair.color == currentColor)
            {
                Renderer renderer = other.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = colorTagPair.interactableMaterial;
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        foreach (ColorTagPair colorTagPair in colorTagPairs)
        {
            if (other.CompareTag(colorTagPair.tag) && colorTagPair.color == currentColor)
            {
                Renderer renderer = other.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = colorTagPair.interactableMaterial;
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (ColorTagPair colorTagPair in colorTagPairs)
        {
            if (other.CompareTag(colorTagPair.tag))
            {
                Renderer renderer = other.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = nonInteractableMaterial;
                }
            }
        }
    }

    void Update()
    {
        Light lightComponent = GetComponentInChildren<Light>();
        if (lightComponent != null)
        {
            currentColor = lightComponent.color;
        }
    }
}

[System.Serializable]
public class ColorTagPair
{
    public Color color;
    public string tag;
    public Material interactableMaterial;
}


