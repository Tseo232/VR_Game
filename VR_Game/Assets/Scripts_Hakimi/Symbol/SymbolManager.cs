using UnityEngine;
using Unity.VRTemplate;

public class SymbolManager : MonoBehaviour
{
    public Animator doorAnimator;

    [Header("Knobs for Each Dial")]
    public XRKnob[] xrKnobs; // Drag 3 XRKnobs here in the Inspector

    [Header("Puzzle Settings")]
    public int totalDials = 3;

    private int dialsSolved = 0;
    private bool puzzleSolved = false;

    public void OnDialSolved()
    {
        if (puzzleSolved) return;

        dialsSolved++;
        Debug.Log($"Dial solved: {dialsSolved}/{totalDials}");

        if (dialsSolved >= totalDials)
        {
            puzzleSolved = true;

            // Disable all XRKnobs after puzzle is fully solved
            foreach (XRKnob knob in xrKnobs)
            {
                if (knob != null)
                    knob.enabled = false;
            }

            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");

            Debug.Log("✅ All dials solved. Door opening!");
        }
    }
}
