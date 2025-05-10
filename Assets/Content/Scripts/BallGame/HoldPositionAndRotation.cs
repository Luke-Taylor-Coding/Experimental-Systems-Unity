using Unity.Mathematics;
using UnityEngine;

public class HoldPositionAndRotation : MonoBehaviour
{
    //script allows an object to hold a position and rotation and reset to it 

    private Vector3 m_position;
    private quaternion m_rotation;

    void Start()
    {
        m_position = transform.position;
        m_rotation = transform.rotation;
    }
    public void SetPositionValue(Vector3 value)
    {
        m_position = value;
    }

    public void SetRotationValue(Quaternion value) 
    { 
        m_rotation = value;
    }

    public void ResetPosition()
    {
        transform.position = m_position;
    }

    public void ResetRotation()
    {
        transform.rotation = m_rotation;
    }

    public void ResetPositionAndRotation()
    {
        transform.position = m_position;
        transform.rotation = m_rotation;
    }

}
