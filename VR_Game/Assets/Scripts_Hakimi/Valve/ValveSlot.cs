using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ValveSlot : MonoBehaviour
{
    public GameObject valve, valveObj, pole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Valve"))
        {
            // Disable grab interaction and physics
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
                grabInteractable.enabled = false;
            Destroy(valveObj);
            pole.SetActive(false);
            valve.SetActive(true);
            // Snap the battery into place
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Parent to the slot for organization (optional)
            other.transform.SetParent(transform);

            // Optional: disable this collider to prevent multiple triggers
            GetComponent<Collider>().enabled = false;
        }
    }
}