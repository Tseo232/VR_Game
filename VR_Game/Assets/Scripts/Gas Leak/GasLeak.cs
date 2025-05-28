using UnityEngine;

public class GasLeak : MonoBehaviour
{
    public ParticleSystem gasEffect;
    public AudioSource hissingSound;
    public bool isSealed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PipeCap") && !isSealed)
        {
            gasEffect.Stop();
            hissingSound.Stop();
            isSealed = true;
            Debug.Log("Leak sealed!");
        }
    }
}
