using UnityEngine;

public class Valve : MonoBehaviour
{
    public ValveManager manager;
    public Animator shrinkAnimator;
    public Animator growAnimator;
    public float requiredRotation = 360f;

    private float lastAngle;
    private float totalRotation;
    private bool activated = false;

    void Start()
    {
        lastAngle = transform.localEulerAngles.y;
    }

    void Update()
    {
        if (activated) return;

        float currentAngle = transform.localEulerAngles.y;
        float deltaAngle = Mathf.DeltaAngle(lastAngle, currentAngle);
        totalRotation += Mathf.Abs(deltaAngle);
        lastAngle = currentAngle;

        // Debug to watch rotation
        Debug.Log($"Total Rotation: {totalRotation}");

        if (totalRotation >= requiredRotation)
        {
            activated = true;
            manager.ValveActivated();

            if (shrinkAnimator != null)
                shrinkAnimator.SetTrigger("Play");

            if (growAnimator != null)
                growAnimator.SetTrigger("Play");

            Debug.Log("Valve fully rotated, animation triggered.");
        }
    }
}
