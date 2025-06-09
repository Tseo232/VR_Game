using UnityEngine;

public class FuseBoxManager : MonoBehaviour
{
    [Header("Door Animation")]
    public Animator door;

    private int correctFusesInserted = 0;

    [Tooltip("How many fuses must be inserted to open the door?")]
    public int totalRequiredFuses = 1;

    public void InsertFuse()
    {
        if (correctFusesInserted >= totalRequiredFuses)
            return;

        correctFusesInserted++;
        Debug.Log("Fuse inserted. Count = " + correctFusesInserted);

        if (correctFusesInserted == totalRequiredFuses)
        {
            TriggerDoorOpen();
        }
    }

    private void TriggerDoorOpen()
    {
        if (door != null)
        {
            door.SetTrigger("Open");
        }
       
    }
}
