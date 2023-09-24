using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{

    [SerializeField] private PlayerColourSelector colourSelectorScript;
    private List<IInteractable> interactionList = new List<IInteractable>();

    void Start()
    {
        colourSelectorScript ??= GetComponentInParent<PlayerColourSelector>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractable>() != null)
        {
            if (!interactionList.Contains(other.gameObject.GetComponent<IInteractable>()))
            {
                interactionList.Add(other.GetComponent<IInteractable>());
                Debug.Log("Found interactable: " + interactionList);
                CheckInteraction(colourSelectorScript.colourSystem.GetColour());
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<IInteractable>() != null)
        {
            if (!interactionList.Contains(other.GetComponent<IInteractable>()))
            {
                interactionList.Add(other.GetComponent<IInteractable>());
            }
        }

        if (interactionList.Count > 0f && (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact")))
        {
            //FOR MYA ;3
            //for (int i = 0; i < interactionList.Count; i++) {
            //    if (colourSelectorScript.colourSystem.GetColour() == interactionList[i].GetColour()) {
            //        interactionList[i].Interact(colourSelectorScript.colourSystem.GetColour());
            //    }
            //}

            foreach (IInteractable interactableObject in interactionList) {
                if (colourSelectorScript.colourSystem.GetColour() == interactableObject.GetColour()) {
                    interactableObject.Interact(colourSelectorScript.colourSystem.GetColour());
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IInteractable>() != null && interactionList.Contains(other.GetComponent<IInteractable>()) && interactionList.Count > 0f)
        {
            other.GetComponent<IInteractable>().Revert();
            interactionList.Remove(other.GetComponent<IInteractable>());
            interactionList.TrimExcess();
        }

    }

    public void CheckInteraction(ColourSystem.LightColour newColor)
    {
        foreach (IInteractable interactableOb in interactionList)
        {
            if (interactableOb.GetColour() == newColor)
            {
                interactableOb.Collision();
            }
            
            else
            {
                interactableOb.Revert();
            }
        }
    }

}
//public class ColorTagPair
//{
//    public Color color;
//    public string tag;
//    public Material interactableMaterial;
//}


