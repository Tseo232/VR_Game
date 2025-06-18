using Unity.VRTemplate;
using UnityEngine;

public class ValveManager : MonoBehaviour
{
    public Animator doorAnimator;
    public AudioSource door;
    public XRKnob XRKnob;

    private bool puzzleSolved = false;

    public void FreezeValveAndTriggerDoor()
    {
        if (puzzleSolved) return;

        XRKnob.enabled = false;
        puzzleSolved = true;

        // Trigger door open animation
        doorAnimator.SetTrigger("Open");
        door.Play();
    }

}
