using UnityEngine;
using TMPro;

public class ClockPuzzle : MonoBehaviour
{
    [Header("Clock Display")]
    public TextMeshPro clockDisplay;

    [Header("Time Settings")]
    public int hour = 0;
    public int minute = 0;
    public int correctHour = 3;
    public int correctMinute = 15;

    [Header("Puzzle Elements")]
    public Animator doorAnimator; // New: Door animator

    void Start()
    {
        UpdateClockDisplay();
    }

    // Public methods to be used with VR buttons or interaction triggers
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

            // Trigger door animation
            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");
        }
        else
        {
            Debug.Log("Incorrect time");
        }
    }

    void UpdateClockDisplay()
    {
        if (clockDisplay != null)
            clockDisplay.text = $"{hour:D2}:{minute:D2}";
    }
}
