using UnityEngine;

public class JumpscareManager : MonoBehaviour
{
    [Header("Jumpscare Settings")]
    [SerializeField] private float delayBeforeJumpscare = 5f;
    [SerializeField] private GameObject monsterToActivate;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpscareSound;

    [Header("UI")]
    [SerializeField] private GameObject winCanvas;

    private float timer = 0f;
    private bool triggered = false;

    private void Start()
    {
        if (monsterToActivate != null)
            monsterToActivate.SetActive(false);

        if (winCanvas != null)
            winCanvas.SetActive(true);
    }

    private void Update()
    {
        if (!triggered)
        {
            timer += Time.deltaTime;

            if (timer >= delayBeforeJumpscare)
            {
                TriggerJumpscare();
                triggered = true;
            }
        }
    }

    void TriggerJumpscare()
    {
        if (monsterToActivate != null)
            monsterToActivate.SetActive(true);

        if (audioSource != null && jumpscareSound != null)
            audioSource.PlayOneShot(jumpscareSound);

        if (winCanvas != null)
            winCanvas.SetActive(false);
    }
}
