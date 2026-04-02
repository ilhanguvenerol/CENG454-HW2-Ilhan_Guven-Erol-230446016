using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-G): cache GetComponent<Rigidbody>() into 'rb' 
    }

    private void OnTriggerEnter(Collider collision)
    {
        // TODO (Task 3-H): if the missile hits the aircraft, apply the chosen penalty 
    }
}