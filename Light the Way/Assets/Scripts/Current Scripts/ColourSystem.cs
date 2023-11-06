using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourSystem
{
    private LightColour m_lightColour;

    public enum LightColour
    {
        White,
        Red,
        Green,
        Blue,
        Yellow,
        Orange,
        Purple,
    };

    public ColourSystem(LightColour baseColour)
    {
        m_lightColour = baseColour;
    }

    public LightColour GetColour()
    {
        return m_lightColour;
    }

    public void SetColour(LightColour newColour)
    {
        m_lightColour = newColour;

    }
}
