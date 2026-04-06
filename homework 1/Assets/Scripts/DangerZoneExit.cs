using UnityEngine;

public class DangerZoneExit : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        // TODO: confirm the Player tag
        if (!other.CompareTag("Player")) return;
        examManager.ExitDangerZone();
        
    }
}
