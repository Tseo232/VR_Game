using UnityEngine;

public class SymbolDial : MonoBehaviour
{
    public SymbolPuzzleManager manager;
    public int correctIndex;
    private int currentIndex = 0;

    public void RotateSymbol()
    {
        currentIndex = (currentIndex + 1) % 4; // assuming 4 symbols
        transform.Rotate(0, 90f, 0);
        manager.CheckPuzzle();
    }

    public bool IsCorrect()
    {
        return currentIndex == correctIndex;
    }
}
