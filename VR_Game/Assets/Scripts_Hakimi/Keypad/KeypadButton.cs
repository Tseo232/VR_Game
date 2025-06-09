using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace NavKeypad
{
    [RequireComponent(typeof(XRSimpleInteractable))]
    public class KeypadButton : MonoBehaviour
    {
        [Header("Value")]
        [SerializeField] private string value;

        [Header("Button Animation Settings")]
        [SerializeField] private float bttnspeed = 0.1f;
        [SerializeField] private float moveDist = 0.0025f;
        [SerializeField] private float buttonPressedTime = 0.1f;

        [Header("Component References")]
        [SerializeField] private Keypad keypad;

        private bool moving;

        private void Awake()
        {
            var interactable = GetComponent<XRSimpleInteractable>();
            interactable.selectEntered.AddListener(OnPressed);
        }

        private void OnPressed(SelectEnterEventArgs args)
        {
            if (!moving)
            {
                keypad.AddInput(value);
                StartCoroutine(MoveSmooth());

                // Optional: Haptic feedback
                if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controller)
                {
                    controller.SendHapticImpulse(0.5f, 0.1f);
                }
            }
        }

        private IEnumerator MoveSmooth()
        {
            moving = true;

            Vector3 startPos = transform.localPosition;
            Vector3 endPos = startPos + new Vector3(0, 0, moveDist);

            float elapsedTime = 0;
            while (elapsedTime < bttnspeed)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / bttnspeed);
                yield return null;
            }

            transform.localPosition = endPos;
            yield return new WaitForSeconds(buttonPressedTime);

            elapsedTime = 0;
            while (elapsedTime < bttnspeed)
            {
                elapsedTime += Time.deltaTime;
                transform.localPosition = Vector3.Lerp(endPos, startPos, elapsedTime / bttnspeed);
                yield return null;
            }

            transform.localPosition = startPos;
            moving = false;
        }
    }
}
