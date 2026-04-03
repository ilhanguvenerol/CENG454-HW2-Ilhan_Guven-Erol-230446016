using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private HUDController hud;

    private bool hasTakenOff = false;
    private bool inDangerZone = false;
    private bool missileCountdown = false;
    private bool missileActive = false;
    private bool threatCleared = false;
    private bool missionComplete = false;


    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD 
        if (!hasTakenOff || missionComplete) return;

        inDangerZone = true;
        missileCountdown = true;
        hud.ShowWarning("Entered a Dangerous Zone!");
        hud.SetStatus("Escape the zone before the missile locks on!");
        Debug.Log("[FlightExamManager] Danger zone entered.");
    }

    public void ExitDangerZone()
    {
        // TODO: mark the threat as cleared and refresh the HUD 
        inDangerZone = false;
        missileCountdown = false;
        missileActive = false;
        threatCleared = true;

        hud.ClearWarning();
        hud.SetStatus("Threat cleared! Find the landing strip.");
        Debug.Log("[FlightExamManager] Danger zone exited – threat cleared.");
    }
}
