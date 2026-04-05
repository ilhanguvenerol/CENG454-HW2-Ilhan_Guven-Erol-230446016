using UnityEngine;
public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        if (missilePrefab == null || launchPoint == null)
        {
            Debug.LogWarning("[MissileLauncher] missilePrefab or launchPoint not assigned.");
            return null;
        }
        // TODO (Task 3-A): instantiate the missile at launchPoint
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        // TODO (Task 3-B): give the missile its target 
        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
            homing.SetTarget(target);
        else
            Debug.LogWarning("[MissileLauncher] Missile prefab is missing MissileHoming component.");

        // TODO (Task 3-C): play launch audio and return the spawned missile 
        return null;
    }

    public void DestroyActiveMissile()
    {
        // TODO (Task 3-D): destroy the current missile safely if one exists 
    }
}