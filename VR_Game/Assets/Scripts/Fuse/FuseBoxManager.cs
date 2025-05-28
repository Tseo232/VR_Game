using UnityEngine;

public class FuseBoxManager : MonoBehaviour
{
    public Light[] lightsToTurnOn; // Assign lights in the inspector
    private int correctFusesInserted = 0;
    public int totalRequiredFuses = 3;

    public void InsertFuse()
    {
        correctFusesInserted++;
        if (correctFusesInserted >= totalRequiredFuses)
        {
            TurnOnLights();
        }
    }

    void TurnOnLights()
    {
        foreach (Light light in lightsToTurnOn)
        {
            light.enabled = true;
        }
        Debug.Log("Lights turned on!");
    }
}
