using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    public static LivesManager Instance;

    public int lives = 3;
    public Transform respawnPoint;
    public GameObject xrOrigin;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    public void PlayerHit()
    {
        lives--;

        if (lives > 0)
        {
            xrOrigin.transform.position = respawnPoint.position;
            xrOrigin.transform.rotation = respawnPoint.rotation;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
