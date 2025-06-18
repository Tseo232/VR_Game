using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour
{
    public GameObject xrOrigin;
    public string winSceneName = "Win";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.IsChildOf(xrOrigin.transform))
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
