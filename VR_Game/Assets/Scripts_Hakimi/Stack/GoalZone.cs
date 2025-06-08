using UnityEngine;

public class GoalZone : MonoBehaviour
{
    public Animator doorAnimator; // Reference to the door's Animator

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stackable"))
        {
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
            }
        }
    }
}
