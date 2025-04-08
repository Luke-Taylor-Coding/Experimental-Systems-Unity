using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour
{
    [SerializeField]
    Transform pos1;
    [SerializeField]
    Transform pos2;

    [SerializeField]
    float m_speed = 1.0f;

    Transform m_position;
    Vector3 m_direction = Vector3.left;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_position = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float f = m_speed * Time.deltaTime;


        if (transform.position.x <= pos1.position.x)
        {
            m_direction = Vector3.right;
        }
        else if (transform.position.x >= pos2.position.x)
        {
            m_direction = Vector3.left;
        }

        transform.Translate(m_direction * f * Time.deltaTime);
    }
}
