using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerColourSelector : MonoBehaviour
{
    private int numberOfColours;

    public ColourSystem colourSystem;
    private ColourSystem.LightColour selectedColour;

    public Light testLight;


    private void Start()
    {
        selectedColour = ColourSystem.LightColour.White;
        colourSystem = new ColourSystem(selectedColour);

        numberOfColours = System.Enum.GetValues(typeof(ColourSystem.LightColour)).Length;
        UpdateTestLightColour();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Change 2"))
        {
            int currCol = (int)selectedColour;
            currCol++;
            if (currCol >= numberOfColours)
                currCol = 0;

            colourSystem.SetColour((ColourSystem.LightColour)currCol);
            selectedColour = colourSystem.GetColour();
            UpdateTestLightColour();
        }
        
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Change 1"))
        {
            int currCol = (int)selectedColour;
            currCol--;
            if (currCol < 0)
                currCol = numberOfColours - 1;

            colourSystem.SetColour((ColourSystem.LightColour)currCol);
            selectedColour = colourSystem.GetColour();
            UpdateTestLightColour();
        }
    }

    private void UpdateTestLightColour()
    {
        if (GetComponentInChildren<InteractionHandler>() != null)
        {
            GetComponentInChildren<InteractionHandler>().CheckInteraction(selectedColour);
        }
        switch (selectedColour)
        {
            case ColourSystem.LightColour.White:
                testLight.color = Color.white;
                break;

            case ColourSystem.LightColour.Red:
                testLight.color = Color.red;
                break;

            case ColourSystem.LightColour.Blue:
                testLight.color = Color.blue;
                break;

            case ColourSystem.LightColour.Green:
                testLight.color = Color.green;
                break;

            case ColourSystem.LightColour.Yellow:
                testLight.color = new Color(1f, 0.92f, 0.016f);
                break;

            case ColourSystem.LightColour.Orange:
                testLight.color = new Color(1f, 0.5f, 0.0f);
                break;
            
            case ColourSystem.LightColour.Purple:
                testLight.color = new Color(0.5f, 0f, 1f);
                break;
        }
    }
}

