using UnityEngine;
using Unity.VRTemplate;

public class SymbolManager : MonoBehaviour
{
    public Animator doorAnimator;
    public XRKnob XRKnob;

    [Header("Puzzle Settings")]
    public int totalDials = 3; // Set to number of dials in the Inspector

    private int dialsSolved = 0;
    private bool puzzleSolved = false;

    // Called by dials when they reach their target
    public void OnDialSolved()
    {
        if (puzzleSolved) return;

        dialsSolved++;
        Debug.Log($"Dial solved: {dialsSolved}/{totalDials}");

        if (dialsSolved >= totalDials)
        {
            puzzleSolved = true;

            if (XRKnob != null)
                XRKnob.enabled = false;

            if (doorAnimator != null)
                doorAnimator.SetTrigger("Open");

            Debug.Log("All dials solved. Door opening!");
        }
    }
}
