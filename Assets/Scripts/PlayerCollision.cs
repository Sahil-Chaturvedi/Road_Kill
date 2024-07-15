using EZCameraShake;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public string targetTag = "Obstacle";
    public CameraShake2 cameraShake2;
    public AudioClip[] collisionSounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collisioninfo)
    {
        if(collisioninfo.collider.tag == "EndTrigger")
        {
            movement.enabled = false;
        }

        if (collisioninfo.gameObject.CompareTag(targetTag))
        {
            cameraShake2.TriggerShake();
            PlayRandomCollisionSound();

        }

    }
    private void PlayRandomCollisionSound()
    {
        if (collisionSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, collisionSounds.Length);
            AudioClip randomClip = collisionSounds[randomIndex];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
