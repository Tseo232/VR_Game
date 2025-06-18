using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterCollision : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject xrOrigin;

    [SerializeField]
    private int lives = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(xrOrigin.transform))
        {
            lives--;

            if (lives > 0)
            {
                xrOrigin.transform.position = spawnPoint.position;
                xrOrigin.transform.rotation = spawnPoint.rotation;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
