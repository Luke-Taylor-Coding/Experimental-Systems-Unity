using UnityEngine;

public class PinCollectionScript : MonoBehaviour
{
    public ScoreManager m_scoreManager;
    public float m_ScorePerPin = 100;

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
            m_scoreManager.AddScore(m_ScorePerPin);
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}
