using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI ragdollHit;

    // Public variable to store the tag of the target objects
    public string targetTag = "Target";

    // Variable to keep track of the number of collisions
    private int collisionCount = 0;

    // HashSet to store the unique game objects that have been counted
    private HashSet<GameObject> countedObjects = new HashSet<GameObject>();

    // Method called when the collider attached to this game object enters a collision
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specified tag and has not been counted yet
        if (collision.gameObject.CompareTag(targetTag) && !countedObjects.Contains(collision.gameObject))
        {
            // Add the game object to the HashSet
            countedObjects.Add(collision.gameObject);
            // Increment the collision count
            collisionCount++;
            

            // Print the current collision count to the console
            Debug.Log("Collisions with " + targetTag + ": " + collisionCount);

            ragdollHit.text = "Score: " + collisionCount.ToString();

        }
    }

    // Method to get the current collision count
    public int GetCollisionCount()
    {
        return collisionCount;
    }
}