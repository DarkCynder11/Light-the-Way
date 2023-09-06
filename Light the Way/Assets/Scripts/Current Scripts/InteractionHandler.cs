using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    [SerializeField] private PlayerColourSelector colourSelectorScript;
    IInteractable interactable = null;

    void Start()
    {
        colourSelectorScript ??= GetComponent<PlayerColourSelector>();
    }

    void OnTriggerEnter(Collider other)
    {
        interactable = other.GetComponent<IInteractable>();
        if (colourSelectorScript.colourSystem.GetColour() == interactable.GetColour())
        {
            interactable.Collision();
        }
    }

    void OnTriggerStay(Collider other)
    {
        interactable = other.GetComponent<IInteractable>();

        if (interactable != null && (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact")))
        {
            if (colourSelectorScript.colourSystem.GetColour() == interactable.GetColour())
            {
                interactable.Interact(colourSelectorScript.colourSystem.GetColour());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        interactable = null;
    }

    void Update()
    {
     
    }
}
//public class ColorTagPair
//{
//    public Color color;
//    public string tag;
//    public Material interactableMaterial;
//}


