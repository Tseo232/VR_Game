using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PowerGenerator : MonoBehaviour
{
    [Header("Socket to check for battery")]
    public XRSocketInteractor batterySocket;

    [Header("Objects to activate")]
    public GameObject[] lightsToTurnOn;
    public AudioSource generatorAudio;
    public ParticleSystem powerEffect;

    private bool isPowered = false;

    void Update()
    {
        if (!isPowered && batterySocket.hasSelection)
        {
            ActivatePower();
        }
    }

    void ActivatePower()
    {
        isPowered = true;
        Debug.Log("Generator powered!");

        // Turn on all lights
        foreach (var lightObj in lightsToTurnOn)
        {
            if (lightObj.TryGetComponent<Light>(out Light light))
            {
                light.enabled = true;
            }
            else
            {
                lightObj.SetActive(true); // fallback
            }
        }

        // Play SFX and VFX
        if (generatorAudio) generatorAudio.Play();
        if (powerEffect) powerEffect.Play();
    }
}

