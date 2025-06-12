using UnityEngine;

public class BatteryManager : MonoBehaviour
{
 
    public GameObject bulb,bulb1, fuse;
    

    [Tooltip("How many batteries must be inserted to turn on the light?")]
    public int requiredBatteries = 2;

    private int batteriesInserted = 0;
    private bool isPowered = false;

    public void InsertBattery()
    {
        if (isPowered)
            return;

        if (batteriesInserted >= requiredBatteries)
            return;

        batteriesInserted++;
        Debug.Log("Battery inserted. Count = " + batteriesInserted);

        if (batteriesInserted == requiredBatteries)
        {
            ActivateSystem();
        }
    }

    private void ActivateSystem()
    {
        isPowered = true;

        if (bulb != null)
        {
            bulb.SetActive(true);
            bulb1.SetActive(true);
            fuse.SetActive(true);
            Debug.Log("System activated: Bulb turned on.");
        }
        else
        {
            Debug.LogWarning("No bulb GameObject assigned.");
        }
    }
}
