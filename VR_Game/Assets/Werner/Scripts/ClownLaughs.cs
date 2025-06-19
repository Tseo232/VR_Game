using UnityEngine;
using System.Collections;

public class ClownLaughs : MonoBehaviour
{
    public AudioClip[] clownLaughs;
    public AudioSource laughAudioSource;
    public float minDelay = 5f;
    public float maxDelay = 12f;

    private void Start()
    {
        StartCoroutine(PlayRandomLaughs());
    }

    private IEnumerator PlayRandomLaughs()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            AudioClip chosenLaugh = clownLaughs[Random.Range(0, clownLaughs.Length)];

            laughAudioSource.clip = chosenLaugh;
            laughAudioSource.Play();
        }
    }
}
