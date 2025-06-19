using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Scene Settings")]
    public float sceneChangeDelay = 3f;

    private float timer = 0f;
    private bool triggered = false;
    private bool countdownStarted = false;

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
                triggered = true;
                TriggerJumpscare();
                countdownStarted = true;
            }
        }

        if (countdownStarted)
        {
            sceneChangeDelay -= Time.deltaTime;
            if (sceneChangeDelay <= 0f)
            {
                SceneManager.LoadScene("Start menu");
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
