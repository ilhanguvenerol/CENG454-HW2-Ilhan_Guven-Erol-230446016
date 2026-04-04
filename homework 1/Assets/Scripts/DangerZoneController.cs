using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        // TODO: confirm the Player tag
        if (!other.CompareTag("Player")) return;
        // TODO: push the warning message "Entered a Dangerous Zone!" to the HUD
        examManager.EnterDangerZone();
        // TODO: start the delayed missile launch countdown 
        if (activeCountdown != null)
            StopCoroutine(activeCountdown);//prevent duplicate countdowns

        activeCountdown = StartCoroutine(MissileCountdown(other.transform));
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO: confirm the Player tag 
        if (!other.CompareTag("Player")) return;
        // TODO: cancel any pending launch countdown
        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }
        // TODO: destroy the active missile and clear the HUD warning 
        missileLauncher.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown(Transform playerTransform)
    {
        yield return new WaitForSeconds(missileDelay);

        
        GameObject missile = missileLauncher.Launch(playerTransform);

        if (missile != null)
            examManager.NotifyMissileActive();

        activeCountdown = null;
    }
}
