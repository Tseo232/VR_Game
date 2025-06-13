using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light lightSource;

    [Header("Flicker Settings")]
    public float minFlickerTime = 0.05f;
    public float maxFlickerTime = 0.3f;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            lightSource.enabled = !lightSource.enabled;
            float waitTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
