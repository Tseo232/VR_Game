using Unity.VRTemplate;
using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public Animator doorAnimator;
    public XRKnob XRKnob;
    public Rigidbody dial;
    private bool puzzleSolved = false;

    public void DisableKnobAndTriggerDoor()
    {
        if (puzzleSolved) return;

        XRKnob.enabled = false;
        puzzleSolved = true;

        // Freeze the Y position of the dial
        dial.constraints |= RigidbodyConstraints.FreezeRotationY;

        // Trigger door open animation
        doorAnimator.SetTrigger("Open");

    }

}
