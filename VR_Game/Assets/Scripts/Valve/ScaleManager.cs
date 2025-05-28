using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public Transform objectToShrink;
    public Transform objectToGrow;
    public float scaleSpeed = 1f;
    public float minYScale = 0.1f;
    public float maxYScale = 2f;

    private bool scaleTriggered = false;

    public void TriggerScaleChange()
    {
        if (!scaleTriggered)
        {
            scaleTriggered = true;
            StartCoroutine(ScaleObjects());
        }
    }

    private System.Collections.IEnumerator ScaleObjects()
    {
        while (objectToShrink.localScale.y > minYScale || objectToGrow.localScale.y < maxYScale)
        {
            if (objectToShrink.localScale.y > minYScale)
            {
                Vector3 scale = objectToShrink.localScale;
                scale.y -= scaleSpeed * Time.deltaTime;
                scale.y = Mathf.Max(scale.y, minYScale);
                objectToShrink.localScale = scale;
            }

            if (objectToGrow.localScale.y < maxYScale)
            {
                Vector3 scale = objectToGrow.localScale;
                scale.y += scaleSpeed * Time.deltaTime;
                scale.y = Mathf.Min(scale.y, maxYScale);
                objectToGrow.localScale = scale;
            }

            yield return null;
        }
    }
}
