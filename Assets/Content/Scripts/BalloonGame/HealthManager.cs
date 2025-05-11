using UnityEngine;
using TMPro;

// LIFE MANAGER    
// holds lives, when lives over call back to game manager game over
// displays lives on UI / updates it 

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int m_lives = 3;
    [SerializeField] private int m_maxLives = 3;

    [SerializeField] private TextMeshProUGUI m_livesText;

    private void LivesChanged()
    {
        //update UI
        m_livesText.text = "Lives: " + m_lives.ToString();
    }

    public void GameEnded()
    {
        m_livesText.text = "GAME OVER";
    }

    public void GameStarted()
    {
        m_lives = m_maxLives;
        LivesChanged();
    }

    public bool TakeLife()
    {
        m_lives--;
        LivesChanged();

        if (m_lives <= 0)
        {
            return true;
        }

        return false;
    }
}
