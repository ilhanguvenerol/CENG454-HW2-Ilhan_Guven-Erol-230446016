using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text warningText;
    [SerializeField] private TMP_Text statusText;
    private void Awake()
    {
        ClearWarning();
        SetStatus("Clear for Takeoff");
    }

    public void ShowWarning(string message)
    {
        if (warningText != null)
            warningText.text = message;
    }

    public void ClearWarning()
    {
        if (warningText != null)
            warningText.text = "";
    }

    public void SetStatus(string message)
    {
        if (statusText != null)
            statusText.text = message;
    }
}
