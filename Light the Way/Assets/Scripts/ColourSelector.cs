using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColourSelector : MonoBehaviour
{
    public enum LightColour
    {
        White,
        Red,
        Green,
        Blue,
        Yellow,
    };

    private int numberOfColours;
    public LightColour selectedColour = LightColour.White;

    public ChangeColour changeColourScript;

    public Light testLight;

    public bool isInteractable = true;
    public Transform teleportTarget; // Teleportation target for green color
    private Vector3 startingPlayerPosition; // Store the player's starting position

    private void Start()
    {
        numberOfColours = System.Enum.GetValues(typeof(LightColour)).Length;

        startingPlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Change 2"))
        {
            int currCol = (int)selectedColour;
            currCol++;
            if (currCol >= numberOfColours)
                currCol = 0;

            selectedColour = (LightColour)currCol;
            UpdateTestLightColour();
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Change 1"))
        {
            int currCol = (int)selectedColour;
            currCol--;
            if (currCol < 0)
                currCol = numberOfColours - 1;

            selectedColour = (LightColour)currCol;
            UpdateTestLightColour();
        }

        // Check for teleportation if the color is green and interactable
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact"))
        {
            if (selectedColour == LightColour.Green && changeColourScript.IsInteractable())
            {
                TeleportPlayer();
            }
        }

        // Check for walkability if the color is blue and interactable
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("Interact"))
        {
            if (selectedColour == LightColour.Blue && changeColourScript.IsInteractable())
            {
                
            }
        }
    }

    private void UpdateTestLightColour()
    {
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

    private void TeleportPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && teleportTarget != null)
        {
            player.transform.position = teleportTarget.position;
            Debug.Log("Player teleported to green object");
        }
        else
        {
            Debug.LogWarning("Player or teleport target not found.");
        }
    }

    private void SetPlayerPhysics(bool useGravity)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.useGravity = useGravity;
            playerRigidbody.isKinematic = !useGravity;
        }
        else
        {
            Debug.LogWarning("Player not found.");
        }
    }

    private void ResetPlayerToStartingPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = startingPlayerPosition;
            Debug.Log("Player reset to starting position");
        }
        else
        {
            Debug.LogWarning("Player not found.");
        }
    }

}

