using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-G): cache GetComponent<Rigidbody>() into 'rb' 
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Missile")) return;

        // Play hit audio
        if (hitAudioSource != null && hitClip != null)
            hitAudioSource.PlayOneShot(hitClip);

        // TODO (Task 3-I): update HUD
        examManager.NotifyMissileHit();

        // TODO (Task 3-K): respawn the aircraft
        Respawn();
    }

    private void Respawn()
    {
        if (respawnPoint == null)
        {
            Debug.LogWarning("[AircraftThreatHandler] No respawn point assigned.");
            return;
        }

        //aircraft shall not carry momentum into the respawn
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.SetPositionAndRotation(respawnPoint.position, respawnPoint.rotation);
        Debug.Log("[AircraftThreatHandler] Aircraft respawned.");
        examManager.NotifyRespawn();
    }
}