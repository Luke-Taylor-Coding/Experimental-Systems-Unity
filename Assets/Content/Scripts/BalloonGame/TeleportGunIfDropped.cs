using UnityEngine;

public class TeleportGunIfDropped : MonoBehaviour
{
    [SerializeField] GameObject m_gun;

    private Transform m_gunTransform;

    private void Start()
    {
        if (m_gun == null)
        {
            Debug.LogError("Gun not set in teleport if dropped over collider");
        }
        else
        {
            m_gunTransform = m_gun.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            //teleport gun to original position without momentum
            other.transform.position = m_gunTransform.position;
            other.transform.rotation = m_gunTransform.rotation;
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
