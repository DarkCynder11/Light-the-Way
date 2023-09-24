using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(ColourSystem.LightColour lightColour);

    ColourSystem.LightColour GetColour();

    void Setup();

    void Collision();

    void Revert();
}
