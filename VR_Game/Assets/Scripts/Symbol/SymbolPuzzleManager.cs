using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public SymbolDial[] dials;
    public Animator doorAnimator; // Reference to Animator

    public void CheckPuzzle()
    {
        foreach (SymbolDial dial in dials)
        {
            if (!dial.IsCorrect()) return;
        }

        doorAnimator.SetTrigger("Open"); // Triggers door animation
        Debug.Log("Puzzle Solved!");
    }
}
