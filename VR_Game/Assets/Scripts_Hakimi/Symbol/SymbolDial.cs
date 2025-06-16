using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SymbolDial : MonoBehaviour
{
    public SymbolManager manager;
    public Rigidbody dial;

    [Header("Dial Settings")]
    [Range(0f, 360f)] public float targetAngle = 35f;
    public float angleThreshold = 1f;

    public TMP_Text angleText;

    private bool triggered = false;
    private XRGrabInteractable grab;

    void Start()
    {
        if (dial == null) dial = GetComponent<Rigidbody>();
        grab = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if (triggered) return;

        float angle = transform.localEulerAngles.y;
        int displayAngle = Mathf.RoundToInt(angle % 360f);

        if (angleText != null)
            angleText.text = $"{displayAngle}°";

        // Check if dial is at the correct angle
        if (Mathf.Abs(Mathf.DeltaAngle(angle, targetAngle)) <= angleThreshold)
        {
            triggered = true;

            // Freeze only this dial's rotation
            if (dial != null)
                dial.constraints |= RigidbodyConstraints.FreezeRotationY;

            // Optional: stop grabbing interaction
            if (grab != null)
                grab.enabled = false;

            // Notify manager this dial is solved
            if (manager != null)
                manager.OnDialSolved();

            Debug.Log($"{gameObject.name} dial solved at {displayAngle}°");
        }
    }
}
