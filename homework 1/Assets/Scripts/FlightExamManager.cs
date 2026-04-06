using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private HUDController hud;

    private bool hasTakenOff = false;
    private bool inDangerZone = false;
    private bool missileCountdown = false;
    private bool missileActive = false;
    private bool threatCleared = false; //TECHNICALLY it is impossible for the player to reach a landing zone while still in danger so a check using this variable is basically useless
    private bool missionComplete = false;


    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD 
        //if (!hasTakenOff || missionComplete) return;

        inDangerZone = true;
        missileCountdown = true;
        hud.ShowWarning("You are flying over enemy territory");
        hud.SetStatus("Fly through the region before they shot you down");
        Debug.Log("[FlightExamManager] Danger zone entered.");
    }

    public void ExitDangerZone()
    {
        // TODO: mark the threat as cleared and refresh the HUD 
        inDangerZone = false;
        missileCountdown = false;
        missileActive = false;
        threatCleared = true;
        hud.SetStatus("Collide with landing zone to finish the level");
        hud.ClearWarning();
        //hud.SetStatus("Threat cleared! Find the landing strip.");//respawn action also triggers this method so it is removed to prevent confusion
        Debug.Log("[FlightExamManager] Danger zone exited – threat cleared.");
    }

    public void NotifyTakeoff()
    {
        if (hasTakenOff) return;
        hasTakenOff = true;
        hud.SetStatus("Reach the next landing zone. Make sure the plane stays in one piece");
        Debug.Log("[FlightExamManager] Takeoff confirmed.");
    }

    public void NotifyMissileActive()
    {
        missileActive = true;
        missileCountdown = false;
        hud.SetStatus("Anti-Aircraft missiles locked and approaching. Take evasive action");
        Debug.Log("[FlightExamManager] Missile is active.");
    }

    public void NotifyMissileHit()
    {
        hud.ShowWarning("MISSILE HIT! Mission failed.");
        hud.SetStatus("Respawning...");
        // Extend later: trigger respawn, reduce health, etc.
        Debug.Log("[FlightExamManager] Missile hit the aircraft.");
    }

    public void NotifyRespawn() {
        hud.SetStatus("Try Again");
    }

    public void TryCompleteMission()
    {
        /*      //I could also have a collision exit check to change the value of boolean variable but its really not that important
        if (!hasTakenOff)
        {
            hud.SetStatus("You must take off first!");
            return;
        }
        */

        if (!threatCleared)
        {
            hud.SetStatus("You cannot land while being targeted");
            return;
        }
        if (missionComplete) return;

        missionComplete = true;
        hud.ClearWarning();
        hud.SetStatus("Congratulations, Pilot. You live to fly another day");
        Debug.Log("[FlightExamManager] Mission complete.");
    }
}
