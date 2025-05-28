using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Beaker Liquid Renderers")]
    public Renderer[] liquidRenderers;

    [Header("Liquid Materials")]
    public Material[] newLiquidMaterials;

    [Header("Optional Reset")]
    public bool revertOnExit = false;
    private Material[] originalMaterials;

    private void Start()
    {
        // Store original materials to revert later
        originalMaterials = new Material[liquidRenderers.Length];
        for (int i = 0; i < liquidRenderers.Length; i++)
        {
            originalMaterials[i] = liquidRenderers[i].material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchLiquids();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && revertOnExit)
        {
            RevertLiquids();
        }
    }

    void SwitchLiquids()
    {
        for (int i = 0; i < liquidRenderers.Length; i++)
        {
            if (i < newLiquidMaterials.Length)
            {
                liquidRenderers[i].material = newLiquidMaterials[i];
            }
        }
    }

    void RevertLiquids()
    {
        for (int i = 0; i < liquidRenderers.Length; i++)
        {
            liquidRenderers[i].material = originalMaterials[i];
        }
    }
}

