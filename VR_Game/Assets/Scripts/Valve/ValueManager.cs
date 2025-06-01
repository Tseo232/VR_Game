using UnityEngine;

public class ValveManager : MonoBehaviour
{
    public int requiredValves = 3;
    private int currentValves = 0;
    public GameObject steamBlocker;

    public void ValveActivated()
    {
        currentValves++;
        if (currentValves >= requiredValves)
        {
            steamBlocker.SetActive(false);
            Debug.Log("Steam diverted!");
        }
    }
}
