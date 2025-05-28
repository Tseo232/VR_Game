using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FuseSlot : MonoBehaviour
{
    public FuseBoxManager manager;
    public GameObject fuse, fuseobj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuse"))
        {
            // Disable grab interaction and physics
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
                grabInteractable.enabled = false;
                Destroy(fuseobj);
                fuse.SetActive(true); 
            // Snap the fuse into place
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            // Parent to the slot for organization (optional)
            other.transform.SetParent(transform);

            // Register fuse insertion
            manager.InsertFuse();

            // Optional: disable this collider to prevent multiple triggers
            GetComponent<Collider>().enabled = false;
        }
    }
}
