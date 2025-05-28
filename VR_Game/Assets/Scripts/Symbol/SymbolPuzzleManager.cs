using UnityEngine;

public class SymbolPuzzleManager : MonoBehaviour
{
    public SymbolDial[] dials;
    public GameObject hiddenDoor;

    public void CheckPuzzle()
    {
        foreach (SymbolDial dial in dials)
        {
            if (!dial.IsCorrect()) return;
        }

        hiddenDoor.SetActive(false); // or animate
        Debug.Log("Puzzle Solved!");
    }
}
