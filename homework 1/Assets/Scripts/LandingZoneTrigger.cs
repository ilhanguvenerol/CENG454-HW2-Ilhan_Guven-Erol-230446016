// LandingZoneTrigger.cs
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingZoneTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float messageDisplayTime = 3f;

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        examManager.TryCompleteMission();
        StartCoroutine(ReloadAfterDelay());
    }

    private IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(messageDisplayTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
