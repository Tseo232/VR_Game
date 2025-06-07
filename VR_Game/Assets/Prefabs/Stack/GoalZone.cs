using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public GameObject symbol;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stackable"))
        {
            symbol.SetActive(true);
        }
    }
}
