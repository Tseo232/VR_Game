using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CubeGoalTrigger : MonoBehaviour
{
    [Header("Settings")]
    public GameObject goalZone;                  // Assign the specific GoalZone GameObject here
    public Animator doorAnimator;                // Door animator to trigger
    public float velocityThreshold = 0.01f;     // Threshold for stationary check
    public float checkDelay = 0.3f;

    private XRGrabInteractable grab;
    private Rigidbody rb;

    private bool isCollidingWithGoalZone = false;
    private bool hasTriggeredDoor = false;

    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();

        grab.selectEntered.AddListener(_ =>
        {
            hasTriggeredDoor = false;
            Debug.Log("Cube picked up: door trigger reset.");
        });

        grab.selectExited.AddListener(_ =>
        {
            if (isCollidingWithGoalZone)
                Invoke(nameof(CheckIfStationaryAndTriggerDoor), checkDelay);
        });
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == goalZone)
        {
            isCollidingWithGoalZone = true;
            Debug.Log("Cube collided with assigned GoalZone.");

            if (!grab.isSelected)
                Invoke(nameof(CheckIfStationaryAndTriggerDoor), checkDelay);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == goalZone)
        {
            isCollidingWithGoalZone = false;
            hasTriggeredDoor = false;
            Debug.Log("Cube exited collision with GoalZone: reset door trigger.");
        }
    }

    private void CheckIfStationaryAndTriggerDoor()
    {
        if (!isCollidingWithGoalZone || hasTriggeredDoor || grab.isSelected)
            return;

        if (rb.linearVelocity.magnitude < velocityThreshold && rb.angularVelocity.magnitude < velocityThreshold)
        {
            Debug.Log("Cube is stationary and collided with GoalZone. Triggering door.");
            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");
            hasTriggeredDoor = true;
        }
        else
        {
            // Retry if not stationary yet
            Invoke(nameof(CheckIfStationaryAndTriggerDoor), 0.2f);
        }
    }
}
