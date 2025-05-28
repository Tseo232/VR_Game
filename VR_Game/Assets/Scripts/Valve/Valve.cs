using UnityEngine;

public class Valve : MonoBehaviour
{
    public ValveManager manager;
    public Animator shrinkAnimator;
    public Animator growAnimator;
    public float correctAngle = 90f;
    public float angleTolerance = 10f;

    private bool activated = false;

    void Update()
    {
        float currentY = transform.localEulerAngles.y;
        float angleDifference = Mathf.Abs(Mathf.DeltaAngle(currentY, correctAngle));

        if (!activated && angleDifference <= angleTolerance)
        {
            activated = true;
            manager.ValveActivated();

            if (shrinkAnimator != null)
                shrinkAnimator.SetTrigger("Play");

            if (growAnimator != null)
                growAnimator.SetTrigger("Play");
        }
    }
}
