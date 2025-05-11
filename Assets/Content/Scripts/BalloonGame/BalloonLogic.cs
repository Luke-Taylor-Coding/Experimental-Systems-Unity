using UnityEngine;

// BALLOONS
// Move towards the center of the tower
// if ballon hits center, call to game manager to take a life, delete balloon
// if poped, de-activate for re calling 

public class BalloonLogic : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_speed = 1f;
    [SerializeField] private BalloonSpawner m_balloonSpawner;

    void Update()
    {
        //check if target is reached
        if (gameObject.transform.position == m_target.transform.position)
        {
            //if so call to balloon manager to take a life
            m_balloonSpawner.BalloonReachedTarget();

            //de-activate
            SetActive(false);
        }
        else
        {
            //move towards target
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_target.transform.position, m_speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if projectile
        if (other.CompareTag("Bullet"))
        {
            //call that balloon has been hit
            m_balloonSpawner.BalloonHit();
            SetActive(false);
        }
    }

    public void SetActive(bool TorF)
    {
        if (!TorF)
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}
