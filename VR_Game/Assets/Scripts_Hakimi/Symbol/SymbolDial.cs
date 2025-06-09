using UnityEngine;

public class SymbolDial : MonoBehaviour
{
    public SymbolPuzzleManager manager;

    [Range(0f, 360f)]
    public float targetAngle = 35f;      // Set this in the Inspector
    public float angleThreshold = 1f;    // Acceptable margin (e.g., ±1 degree)

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        float currentY = transform.eulerAngles.y % 360f;

        // If dial is within the threshold of targetAngle
        if (Mathf.Abs(Mathf.DeltaAngle(currentY, targetAngle)) <= angleThreshold)
        {
            triggered = true;
            manager.DisableKnobAndTriggerDoor();
        }
    }
}
