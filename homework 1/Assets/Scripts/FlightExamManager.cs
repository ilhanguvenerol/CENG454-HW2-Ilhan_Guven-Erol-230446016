using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private HUDController hud;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD 
    }

    public void ExitDangerZone()
    {
        // TODO: mark the threat as cleared and refresh the HUD 
    }
}
