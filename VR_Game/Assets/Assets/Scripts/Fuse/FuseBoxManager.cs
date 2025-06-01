using UnityEngine;

public class FuseBoxManager : MonoBehaviour
{
    public Light bulbLight;
    public MeshRenderer bulbRenderer;
    public Material bulbOnMaterial;

    private int correctFusesInserted = 0;

    [Tooltip("How many fuses must be inserted to turn on the light?")]
    public int totalRequiredFuses = 3;

    public void InsertFuse()
    {
        // Prevent going over
        if (correctFusesInserted >= totalRequiredFuses)
            return;

        correctFusesInserted++;
        Debug.Log("Fuse inserted. Count = " + correctFusesInserted);

        if (correctFusesInserted == totalRequiredFuses)
        {
            TurnOnBulb();
        }
    }

    void TurnOnBulb()
    {
        Debug.Log("All fuses inserted. Turning on bulb.");

        if (bulbLight != null)
            bulbLight.enabled = true;

        if (bulbRenderer != null && bulbOnMaterial != null)
            bulbRenderer.material = bulbOnMaterial;
    }
}
