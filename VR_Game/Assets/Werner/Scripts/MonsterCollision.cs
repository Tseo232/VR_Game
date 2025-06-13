using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    public Transform spawnPoint; // Assign this in the Inspector
    public GameObject xrOrigin;  // Assign this in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == xrOrigin)
        {
            // Teleport XR Origin to the spawn point
            xrOrigin.transform.position = spawnPoint.position;
            xrOrigin.transform.rotation = spawnPoint.rotation;
        }
    }
}
