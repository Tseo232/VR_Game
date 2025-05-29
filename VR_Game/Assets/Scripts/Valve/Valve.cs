using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Valve : MonoBehaviour
{
    public ValveManager manager;
    public Animator shrinkAnimator;
    public Animator growAnimator;
    public float requiredRotation = 360f;

    private float lastAngle;
    private float totalRotation;
    private bool activated = false;

    private Rigidbody rb;
    private XRGrabInteractable grab;
    private HingeJoint hinge;

    void Start()
    {
        lastAngle = transform.localEulerAngles.y;

        // Get components to disable later
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (activated) return;

        float currentAngle = transform.localEulerAngles.y;
        float deltaAngle = Mathf.DeltaAngle(lastAngle, currentAngle);
        totalRotation += Mathf.Abs(deltaAngle);
        lastAngle = currentAngle;

        Debug.Log($"Total Rotation: {totalRotation}");

        if (totalRotation >= requiredRotation)
        {
            activated = true;

            // Trigger game logic
            manager.ValveActivated();

            if (shrinkAnimator != null)
                shrinkAnimator.SetTrigger("Play");

            if (growAnimator != null)
                growAnimator.SetTrigger("Play");

            Debug.Log("Valve fully rotated, animation triggered.");

            // ?? Lock valve in place
            LockValve();
        }
    }

    private void LockValve()
    {
        if (grab != null)
            grab.enabled = false; // Prevent future grabbing

        if (hinge != null)
            Destroy(hinge); // Remove hinge to freeze rotation

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
