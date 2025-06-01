using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    public Transform hourHand, minuteHand;
    public float correctHourAngle = 90f; // 3 o'clock
    public float correctMinuteAngle = 90f; // 15 minutes
    public float tolerance = 10f;
    public GameObject reward;

    void Update()
    {
        if (IsAngleCorrect(hourHand.localEulerAngles.z, correctHourAngle) &&
            IsAngleCorrect(minuteHand.localEulerAngles.z, correctMinuteAngle))
        {
            reward.SetActive(true);
        }
    }

    bool IsAngleCorrect(float current, float target)
    {
        return Mathf.Abs(Mathf.DeltaAngle(current, target)) <= tolerance;
    }
}
