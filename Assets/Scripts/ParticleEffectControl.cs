using UnityEngine;

public class ParticleEffectControl : MonoBehaviour
{
    private ParticleSystem[] particleSystems;

    // Start is called before the first frame update
    void Start()
    {
        // Get all Particle System components from the child GameObjects
        particleSystems = GetComponentsInChildren<ParticleSystem>(true); // The 'true' parameter includes inactive children
    }

    // OnTriggerEnter is called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with this GameObject
        if (other.CompareTag("Player"))
        {
            // Loop through each particle system and play if it's not already playing
            foreach (var ps in particleSystems)
            {
                if (ps != null && !ps.isPlaying)
                {
                    // Enable the GameObject if it's disabled
                    ps.gameObject.SetActive(true);
                    // Play the particle system
                    ps.Play();
                }
            }
        }
    }
}
