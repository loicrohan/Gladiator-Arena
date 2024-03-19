using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public int damageAmount = 1;

    // Check if the collider belongs to the player
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            // Get the PlayerController component attached to the player object
            PlayerHealth playerController = hit.collider.GetComponent<PlayerHealth>();

            // Ensure the PlayerController component exists
            if (playerController != null)
            {
                // Call the TakeDamage method of the PlayerController component
                playerController.TakeDamage(damageAmount);
            }
            else
            {
                Debug.LogWarning("PlayerController component not found on the player object.");
            }
        }
    }
}