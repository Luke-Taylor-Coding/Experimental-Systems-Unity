using UnityEngine;

public class PinCollectionScript : MonoBehaviour
{
    public ScoreManager m_scoreManager;
    public BallGameManager m_ballGameManager;
    public int m_pinsNeededForRespawn = 5;
    private int m_currentPinsHit = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (m_scoreManager == null)
        {
            Debug.LogError("Score Manager is not set in Pin Destrotor Object!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            other.gameObject.SetActive(false);

            m_scoreManager.PinScored();

            //increment the number of pins hit and check if need to respawn
            m_currentPinsHit++; 
            CheckForRespawnNeeded();
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }

    private void CheckForRespawnNeeded()
    {
        if (m_currentPinsHit >= m_pinsNeededForRespawn)
        {
            //call game manager to respawn pins
            m_ballGameManager.RespawnPins();
            m_currentPinsHit = 0;
        }
    }
}
