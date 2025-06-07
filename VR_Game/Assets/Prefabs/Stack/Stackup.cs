using UnityEngine;

public class Stackup : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTrans;
    public Rigidbody objRigidbody;

    private Collider objCollider;
    public static bool holdingItem = false;

    private bool interactable = false;
    private bool pickedup = false;

    public Vector3 holdPosition = new Vector3(0, 0, 1.5f);

    public float scrollSensitivity = 1f;
    public float minHoldDistance = 0.5f;
    public float maxHoldDistance = 3f;

    public float smoothSpeed = 10f;
    public LayerMask snapLayer;
    public float snapRange = 0.2f;

    public AudioSource pickUpSound;

    void Start()
    {
        objCollider = GetComponent<Collider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && !holdingItem)
        {
            crosshair1?.SetActive(false);
            crosshair2?.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") && !pickedup)
        {
            crosshair1?.SetActive(true);
            crosshair2?.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable && Input.GetMouseButton(0) && !pickedup && !holdingItem)
        {
            PickUpObject();
        }

        if (pickedup && Input.GetMouseButtonUp(0))
        {
            DropObject();
        }

        if (pickedup && Input.GetMouseButtonDown(1))
        {
            DropObject();
        }

        if (pickedup)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(scroll) > 0.01f)
            {
                holdPosition.z += scroll * scrollSensitivity;
                holdPosition.z = Mathf.Clamp(holdPosition.z, minHoldDistance, maxHoldDistance);
            }
        }
    }

    void FixedUpdate()
    {
        if (pickedup)
        {
            Vector3 targetPosition = cameraTrans.TransformPoint(holdPosition);
            Quaternion targetRotation = cameraTrans.rotation;

            // Raycast to snap to surface if close
            Ray ray = new Ray(cameraTrans.position, cameraTrans.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, maxHoldDistance, snapLayer))
            {
                if (Vector3.Distance(hit.point, targetPosition) < snapRange)
                {
                    targetPosition = hit.point;
                    targetRotation = Quaternion.LookRotation(hit.normal) * Quaternion.Euler(90, 0, 0); // Adjust rotation if needed
                }
            }

            objTransform.position = Vector3.Lerp(objTransform.position, targetPosition, Time.fixedDeltaTime * smoothSpeed);
            objTransform.rotation = Quaternion.Lerp(objTransform.rotation, targetRotation, Time.fixedDeltaTime * smoothSpeed);
        }
    }

    void PickUpObject()
    {
        if (pickUpSound != null)
            pickUpSound.Play();

        objTransform.parent = cameraTrans;

        objRigidbody.linearVelocity = Vector3.zero;
        objRigidbody.angularVelocity = Vector3.zero;
        objRigidbody.useGravity = false;
        objRigidbody.isKinematic = true;

        if (objCollider != null) objCollider.enabled = false;

        pickedup = true;
        holdingItem = true;
    }

    void DropObject()
    {
        objTransform.parent = null;

        objRigidbody.isKinematic = false;
        objRigidbody.useGravity = true;
        objRigidbody.linearVelocity = Vector3.zero;
        objRigidbody.angularVelocity = Vector3.zero;

        if (objCollider != null) objCollider.enabled = true;

        pickedup = false;
        holdingItem = false;

        crosshair1?.SetActive(true);
        crosshair2?.SetActive(false);
        interactable = false;
    }
}
