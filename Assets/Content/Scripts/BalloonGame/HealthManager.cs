using UnityEngine;

// LIFE MANAGER    
// holds lives, when lives over call back to game manager game over
// displays lives on UI / updates it 

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int m_lives = 3;
    [SerializeField] private int m_maxLives = 3;


    private void LivesChanged()
    {
        //update UI
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

    public void ResetLives()
    {
        m_lives = m_maxLives;
        LivesChanged();
    }
}
