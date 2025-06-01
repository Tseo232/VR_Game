using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public SymbolDial[] dials;
    public Animator doorAnimator;
    private bool puzzleSolved = false;

    public void CheckPuzzle()
    {
        if (puzzleSolved) return;

        foreach (SymbolDial dial in dials)
        {
            if (!dial.IsCorrect()) return;
        }

        puzzleSolved = true;
        doorAnimator.SetTrigger("Open");
        Debug.Log("Puzzle Solved!");
    }
}
