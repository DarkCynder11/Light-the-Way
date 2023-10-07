using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSeeThrough : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material WallMaterial;
    public Camera Camera;
    public LayerMask Mask;

    void Update()
    {
        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, Mask))
        {
            WallMaterial.SetFloat(SizeID, 1);
            Debug.Log("hit");
        }

        else
        {
            WallMaterial.SetFloat(SizeID, 0);
            Debug.Log("no hit");
        }

        var view = Camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PosID, view);
    }

}
