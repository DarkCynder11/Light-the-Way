using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int scoreValue = 1; // The value of the collectible (e.g., score points)
    public AudioClip collectSound; // Sound effect to play when the collectible is collected

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();

        }
    }

    private void Collect()
    {
        // Update the player's score
        GameManager.Instance.AddScore(scoreValue);

        // Play a sound effect
        AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Remove the collectible from the scene
        Destroy(this.gameObject);
        Debug.Log("Destroyed?");

    }
}

