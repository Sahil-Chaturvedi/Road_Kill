using UnityEngine;
using System.Collections;

public class CameraShake2 : MonoBehaviour
{
    // Variables to control the shake effect
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.7f;

    // Reference to the camera's original follow script
    private FollowPlayer cameraFollow;
    private Vector3 originalPosition;

    private void Awake()
    {
        // Get the CameraFollow component
        cameraFollow = GetComponent<FollowPlayer>();
    }

    public void TriggerShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Store the original position
            originalPosition = transform.position;

            // Get the updated desired position from the follow script
            Vector3 desiredPosition = cameraFollow.player.position + cameraFollow.offset;

            // Create a random shake offset
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            float z = Random.Range(-1f, 1f) * shakeMagnitude;

            // Apply the shake offset to the desired position
            transform.position = new Vector3(desiredPosition.x + x, desiredPosition.y + y, desiredPosition.z + z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset the camera to the final desired position after shaking
        Vector3 finalDesiredPosition = cameraFollow.player.position + cameraFollow.offset;
        transform.position = Vector3.Lerp(transform.position, finalDesiredPosition, cameraFollow.smoothSpeed);
    }
}