using UnityEngine;

public class MonsterFootsteps : MonoBehaviour
{
    public Transform player;
    public float hearDistance = 15f;
    public AudioSource footstepAudioSource;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= hearDistance)
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play();
            }
        }
        else
        {
            if (footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Pause();
            }
        }
    }
}
