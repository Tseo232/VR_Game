using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Valve : MonoBehaviour
{
    [Header("Valve Settings")]
    public ValveManager manager;
    public Animator shrinkAnimator;
    public GameObject time;
    public Animator growAnimator;
    public Animator door;
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

        rb = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (activated) return;

        float currentAngle = transform.localEulerAngles.y;
        float deltaAngle = Mathf.DeltaAngle(lastAngle, currentAngle);
        totalRotation += deltaAngle;
        lastAngle = currentAngle;

        Debug.Log($"Signed Total Rotation: {totalRotation}");

        if (Mathf.Abs(totalRotation) >= requiredRotation)
        {
            activated = true;

            manager.ValveActivated();

            if (shrinkAnimator != null)
                shrinkAnimator.SetTrigger("Play");

            if (growAnimator != null)
                growAnimator.SetTrigger("Play");

            if (door != null)
            {
                door.SetTrigger("Open"); // ✅ Trigger the door animation
                time.SetActive(true);
            }
                

            Debug.Log("Valve fully rotated (in either direction), animations triggered.");

            LockValve();
        }
    }

    private void LockValve()
    {
        if (grab != null)
            grab.enabled = false;

        if (hinge != null)
            Destroy(hinge);

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
