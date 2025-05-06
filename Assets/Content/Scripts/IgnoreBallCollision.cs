using UnityEngine;

public class IgnoreBallCollision : MonoBehaviour
{
    public Transform m_ballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform ball = Instantiate(m_ballPrefab) as Transform;
        Physics.IgnoreCollision(ball.GetComponent<Collider>(), GetComponent<Collider>(), true);
    }

}
