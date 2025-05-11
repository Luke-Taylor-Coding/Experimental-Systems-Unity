using UnityEngine;

public class TeleportGunIfDropped : MonoBehaviour
{
    [SerializeField] GameObject m_gun;

    private Transform m_gunTransform;
    private Vector3 m_gunOriginalPosition;
    private Quaternion m_gunOriginalRotation;

    private void Start()
    {
        if (m_gun == null)
        {
            Debug.LogError("Gun not set in teleport if dropped over wall");
        }
        else
        {
            m_gunTransform = m_gun.transform;
            m_gunOriginalPosition = m_gunTransform.position;
            m_gunOriginalRotation = m_gunTransform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun"))
        {
            //teleport gun to original position without momentum
            other.transform.position = m_gunOriginalPosition;
            other.transform.rotation = m_gunOriginalRotation;
            other.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
