using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class BatterySlot : MonoBehaviour
{
    public BatteryManager manager;
    public GameObject battery, batteryobj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == batteryobj)
        {
            // Disable grab interaction and physics
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
                grabInteractable.enabled = false;
            Destroy(batteryobj);
            battery.SetActive(true);
            // Snap the battery into place
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Parent to the slot for organization (optional)
            other.transform.SetParent(transform);

            // Register battery insertion
            manager.InsertBattery();

            // Optional: disable this collider to prevent multiple triggers
            GetComponent<Collider>().enabled = false;
        }
    }
}
