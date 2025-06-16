using UnityEngine;
using TMPro;

public class Valve : MonoBehaviour
{
    public ValveManager manager;
    public Animator shrink, grow;
    public Rigidbody valve;

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
            valve.constraints |= RigidbodyConstraints.FreezeRotationY;
            manager.FreezeValveAndTriggerDoor();

            if (shrink != null)
                shrink.SetTrigger("Play");

            if (grow != null)
                grow.SetTrigger("Play");

        }
    }
}
