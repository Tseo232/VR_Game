using Unity.VRTemplate;
using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public Animator doorAnimator;
    public XRKnob XRKnob;
    private bool puzzleSolved = false;

    public void DisableKnobAndTriggerDoor()
    {
        if (puzzleSolved) return;

        XRKnob.enabled = false;
        puzzleSolved = true;
        doorAnimator.SetTrigger("Open");
        Debug.Log("Dial reached target angle — Door Opened!");
    }
}
