using UnityEngine;

public class MonsterCollision : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject xrOrigin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == xrOrigin)
        {
            xrOrigin.transform.position = spawnPoint.position;
            xrOrigin.transform.rotation = spawnPoint.rotation;
        }
    }
}
