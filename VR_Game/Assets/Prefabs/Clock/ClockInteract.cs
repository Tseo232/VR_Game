using UnityEngine;

public class ClockInteract : MonoBehaviour
{
    public GameObject panel, crosshair2, crosshair;
    public Transform objTransform, cameraTrans;
    public bool interactable, interacted;
    public bool permanentlyDisabled = false;

    public AudioSource interactSound; // <-- Sound to play on interaction

    void OnTriggerStay(Collider other)
    {
        if (permanentlyDisabled) return;

        if (other.CompareTag("MainCamera"))
        {
            crosshair2.SetActive(true);
            crosshair.SetActive(false);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (permanentlyDisabled) return;

        if (other.CompareTag("MainCamera"))
        {
            if (!interacted)
            {
                ShowCursor(true);
                crosshair2.SetActive(false);
                crosshair.SetActive(true);
                interactable = false;
            }
            else
            {
                panel.SetActive(false);
                ShowCursor(false);
                crosshair.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                interacted = false;
            }
        }
    }

    void Update()
    {
        if (permanentlyDisabled) return;

        if (interactable && Input.GetMouseButtonDown(0))
        {
            if (interactSound != null)
                interactSound.Play(); // Play sound when interacting

            panel.SetActive(true);
            ShowCursor(true);
            interacted = true;
        }

        if (interacted && Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
            ShowCursor(false);
            interacted = false;
        }
    }

    void ShowCursor(bool show)
    {
        Cursor.visible = show;
        Cursor.lockState = show ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
