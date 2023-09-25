using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private int scoreValue = 1; // The value of the collectible (e.g., score points)
    [SerializeField] private AudioClip collectSound; // Sound effect to play when the collectible is collected
    //private GameManager gameManager;

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
        //GameManager.Instance.AddScore(scoreValue);

        // Play a sound effect
        AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Remove the collectible from the scene
        Debug.Log("Destroyed?");
        Destroy(gameObject);

    }
}

