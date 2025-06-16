using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ExamineInteractable : XRGrabInteractable
{
    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public Transform examinePoint; // Empty GameObject in front of the camera

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        originalParent = transform.parent;
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;

        // Snap to examine point
        transform.SetParent(examinePoint);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        // Optional: disable gravity
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Return to original position
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
        transform.localRotation = originalRotation;

        // Re-enable gravity
        if (TryGetComponent(out Rigidbody rb))
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
    }
}
