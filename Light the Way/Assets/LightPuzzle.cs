using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPuzzle : MonoBehaviour
{
    private int lightCount = 0;
    private int maxLight = 5;
    List<string> lightNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCount(int value, string lanternName)
    {
        if (value > 0)
        {
            if (!lightNames.Contains(lanternName))
            {

                lightNames.Add(lanternName);

                lightCount += value;

                if (lightCount >= maxLight)
                {
                    Debug.Log("open door");
                    //destroy game object with a reference 
                }
            }
        }
        else
        {
            if (lightNames.Contains(lanternName))
            {
                lightNames.Remove(lanternName);
                lightCount += value;
                if (lightCount < 0)
                {
                    lightCount = 0;
                }
            }
        }
        //removes elements if they get removed prior to the event triggering
        lightNames.TrimExcess();
        Debug.Log(lightCount);
    }

}
