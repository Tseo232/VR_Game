using UnityEngine;

public class FuseSlot : MonoBehaviour
{
    public FuseBoxManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuse"))
        {
            manager.InsertFuse();
            Destroy(other.gameObject); // Or snap into place
        }
    }
}
