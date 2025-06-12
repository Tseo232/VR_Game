using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform respawnPoint;  // Assign the Transform to respawn at
    public string playertag = "Player";  // The tag on the monster object

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playertag))
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        Debug.Log("Player collided with monster. Respawning...");

        // Reset position and zero velocity
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
