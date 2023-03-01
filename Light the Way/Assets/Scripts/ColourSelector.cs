using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSelector : MonoBehaviour
{
    //Enum my beloved
    public enum LightColour
    {
        White,
        Red,
        Green,
        Blue,
        Yellow,
    };
    //Enums don't naturally tell you how many items they have so we have to keep track of it ourselves
    private int numberOfColours;
    //The actual selected colour that we can check when interacting with things
    public LightColour selectedColour = LightColour.White;


    //Testing stuff
    public Light testLight;


    void Start()
    {
        //As you can see it's kinda gross to get Enum count, so let's only do it once
        numberOfColours = System.Enum.GetValues(typeof(LightColour)).Length;
    }


    void Update()
    {
        //Player wants next colour
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Change 2"))
        {
            //Turn our enum into a number so we can increase it easily
            int currCol = (int)selectedColour;
            currCol++;
            //Let the player loop back around to the first colour if they try to go past the last one
            if (currCol >= numberOfColours)
                currCol = 0;

            //Turn our number back into the appropriate enum
            selectedColour = (LightColour)currCol;
            //Update our debug light for rave show fun
            UpdateTestLightColour();

        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Change 1")) //Player wants previous colour
        {
            int currCol = (int)selectedColour;
            currCol--;
            //Loop to end
            if (currCol < 0)
                currCol = numberOfColours - 1;

            selectedColour = (LightColour)currCol;
            UpdateTestLightColour();
        }

    }

    private void UpdateTestLightColour()
    {
        //Switch my beloved
        switch (selectedColour)
        {
            case LightColour.White:
                testLight.color = Color.white;
                break;

            case LightColour.Red:
                testLight.color = Color.red;
                break;

            case LightColour.Blue:
                testLight.color = Color.blue;
                break;

            case LightColour.Green:
                testLight.color = Color.green;
                break;

            case LightColour.Yellow:
                testLight.color = new Color(1f, 0.92f, 0.016f);
                break;
        }
    }
}
