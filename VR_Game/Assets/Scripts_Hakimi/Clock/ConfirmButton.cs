using UnityEngine;

public class ConfirmTimeButton : MonoBehaviour
{
    public ClockPuzzle clockPuzzle;

    public void Confirm()
    {
        if (clockPuzzle != null)
            clockPuzzle.CheckTime();
    }
}
