using UnityEngine;

public class ClockButton : MonoBehaviour
{
    public ClockPuzzle puzzle;
    public string action;

    public void OnActivate()
    {
        if (puzzle == null) return;

        switch (action)
        {
            case "IncreaseHour": puzzle.IncreaseHour(); break;
            case "DecreaseHour": puzzle.DecreaseHour(); break;
            case "IncreaseMinute": puzzle.IncreaseMinute(); break;
            case "DecreaseMinute": puzzle.DecreaseMinute(); break;
            case "CheckTime": puzzle.CheckTime(); break;
        }
    }
}
