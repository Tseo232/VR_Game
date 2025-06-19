using UnityEngine;

public class FlickerSound : MonoBehaviour
{
    public Transform player;
    public AudioSource audioSource;
    public float triggerDistance = 15f;

    private void Update()
    {
        if (player == null || audioSource == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
        }
    }
}
