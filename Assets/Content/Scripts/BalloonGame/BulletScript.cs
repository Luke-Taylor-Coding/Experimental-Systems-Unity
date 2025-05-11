using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float m_speed = 10f;
    public float m_lifetime = 4f;
    private float m_lifetimeRemaining = 4f;
    private Rigidbody m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 direction)
    {
        gameObject.SetActive(true);
        m_lifetimeRemaining = m_lifetime;

        m_rb.linearVelocity = direction * m_speed;
    }

    void Update()
    {
        //set inactive after a certain time
        m_lifetimeRemaining -= Time.deltaTime;
        if (m_lifetimeRemaining <= 0f)
        {
            gameObject.SetActive(false);
            gameObject.transform.position = Vector3.zero;
            m_rb.linearVelocity = Vector3.zero;
            m_rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.zero;
        m_rb.linearVelocity = Vector3.zero;
        m_rb.angularVelocity = Vector3.zero;
    }
}
