using UnityEngine;

public class TeleportPlayerToTransform : MonoBehaviour
{
    // when player enters the area, teleport them to the transform

    [SerializeField] Transform m_transformToTeleportTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = m_transformToTeleportTo.position;
            other.gameObject.transform.rotation = m_transformToTeleportTo.rotation;
        }
    }
}
