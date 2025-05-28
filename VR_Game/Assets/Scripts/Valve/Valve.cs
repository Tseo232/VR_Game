using UnityEngine;

public class Valve : MonoBehaviour
{
    public ValveManager manager;
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
        }
    }
}

