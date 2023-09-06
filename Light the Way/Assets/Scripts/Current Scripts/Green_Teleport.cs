using UnityEngine;

public class Green_Teleport : MonoBehaviour, IInteractable
{
    public Transform teleportTarget; // Teleportation target for green color
    public ColourSystem m_colourSystem;
    Renderer renderer;
    float timer;
    public Material inactiveMaterial, activeMaterial;

    private void Awake()
    {
        m_colourSystem = new ColourSystem(ColourSystem.LightColour.Green);
        renderer = GetComponent<Renderer>();
        renderer.material = inactiveMaterial;
    }



    public void Interact(ColourSystem.LightColour playerColour)
    {
        timer = 5f;
        renderer.material = activeMaterial;
        Debug.Log("interacted");
        TeleportPlayer();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
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
    public ColourSystem.LightColour GetColour() {
        return m_colourSystem.GetColour();
    }

}
