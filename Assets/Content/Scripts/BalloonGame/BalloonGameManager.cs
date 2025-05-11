using UnityEngine;

// GAME MANAGER
// holds game timer to gradually increase both difficulty and score
// when balloon hit, call to life manager and get back a bool if lives = 0 or not
// Resets all systems when game over 

public class BalloonGameManager : MonoBehaviour
{
    private bool m_gameActive = false;
    private float m_gameTime = 0;
    public float m_intervalsBetweenDifficulty = 30f; //seconds
    public float m_spawnTimeDecrease = 0.75f; //seconds

    [SerializeField] BalloonSpawner m_balloonSpawner;
    [SerializeField] HealthManager m_healthManager;
    [SerializeField] BalloonScoreManager m_balloonScoreManager;

    void Update()
    {
        if (m_gameActive)
        {
            //count game time
            m_gameTime += Time.deltaTime;

            if (m_gameTime >= m_intervalsBetweenDifficulty)
            {
                m_gameTime = 0f;
                m_balloonSpawner.SubtractSpawnTime(m_spawnTimeDecrease);
            }
        }
    }

    public void TakeLife()
    {
        //call to life manager to take a life
        //if lives = 0 game over
        if (m_healthManager.TakeLife())
        {
            GameOver();
        }
    }

    public void AddScore()
    {
        m_balloonScoreManager.BalloonScored();
    }

    public void GameOver()
    {
        if (!m_gameActive)
        {
            return;
        }

        m_gameActive = false;
        //call to life manager to reset lives
        m_healthManager.GameEnded();

        //call to score manager to reset score
        m_balloonScoreManager.SetActive(false);

        //call to balloon spawner to stop
        m_balloonSpawner.SetActive(false);

        //reset game time
        m_gameTime = 0f;
    }

    public void GameStart()
    {
        if (m_gameActive)
        {
            return;
        }

        m_gameActive = true;

        //call to balloon spawner to start spawning
        m_balloonSpawner.SetActive(true);

        //call life manager
        m_healthManager.GameStarted();

        //call to score manager to set game active
        m_balloonScoreManager.SetActive(true);
        m_balloonScoreManager.SetScore(0);
    }
}
