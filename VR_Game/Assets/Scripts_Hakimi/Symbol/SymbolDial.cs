using UnityEngine;
using TMPro;

public class SymbolDial : MonoBehaviour
{
    public SymbolManager manager;
    public Rigidbody dial;

    [Range(0f, 360f)]
    public float targetAngle = 35f;
    public float angleThreshold = 1f;

    public TMP_Text angleText;

    private bool triggered = false;

    void Update()
    {
       if (triggered) return;

        Vector3 rotation = transform.localEulerAngles;
        float angle = rotation.y; // Change to Z or X if needed

        Debug.Log($"Dial Rotation Y: {angle}");

        int angleInt = Mathf.RoundToInt(angle % 360f);
        angleText.text = $"{angleInt}°";

        if (Mathf.Abs(Mathf.DeltaAngle(angle, targetAngle)) <= angleThreshold)
        {
            triggered = true;
            dial.constraints |= RigidbodyConstraints.FreezeRotationY;
            manager.DisableKnobAndTriggerDoor();

        }
    }
}
