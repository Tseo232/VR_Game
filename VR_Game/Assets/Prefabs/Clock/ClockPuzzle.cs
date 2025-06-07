using UnityEngine;
using TMPro;

public class ClockPuzzle : MonoBehaviour
{
    public TextMeshProUGUI clockDisplay;

    public int hour = 0;
    public int minute = 0;

    public int correctHour = 3;
    public int correctMinute = 15;

    public GameObject symbol, panel, crosshair2;

    public ClockInteract clockInteract; // Reference to the interaction script

    void Start()
    {
        UpdateClockDisplay();

        // Auto-assign ClockInteract if not set
        if (clockInteract == null)
        {
            clockInteract = GetComponent<ClockInteract>();
        }
    }

    public void IncreaseHour()
    {
        hour = (hour + 1) % 24;
        UpdateClockDisplay();
    }

    public void DecreaseHour()
    {
        hour = (hour - 1 + 24) % 24;
        UpdateClockDisplay();
    }

    public void IncreaseMinute()
    {
        minute = (minute + 1) % 60;
        UpdateClockDisplay();
    }

    public void DecreaseMinute()
    {
        minute = (minute - 1 + 60) % 60;
        UpdateClockDisplay();
    }

    public void CheckTime()
    {
        if (hour == correctHour && minute == correctMinute)
        {
            Debug.Log("Correct Time!");

            // Hide the panel and cursor
            if (panel != null)
                panel.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            // Show reward (e.g., symbol)
            if (symbol != null)
                symbol.SetActive(true);

            // Fully disable future interaction
            if (clockInteract != null)
            {
                clockInteract.permanentlyDisabled = true;
                clockInteract.interactable = false;
                clockInteract.interacted = false;

                if (crosshair2 != null)
                    crosshair2.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Incorrect time");
        }
    }

    void UpdateClockDisplay()
    {
        clockDisplay.text = $"{hour:D2}:{minute:D2}";
    }
}
