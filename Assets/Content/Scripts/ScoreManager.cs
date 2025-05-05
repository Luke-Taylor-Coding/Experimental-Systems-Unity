using UnityEngine;
using UnityEditor;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private bool m_isActive = false;

    private float m_score = 0;
    private float m_highScore = 0;

    public float m_ScorePerPin = 100;
    public float m_ScorePerPinHard = 200;

    public bool m_hardModeEnabled = false;

    public TextMeshProUGUI m_scoreUI = null;
    public TextMeshProUGUI m_highScoreUI = null;


    public void PinScored()
    {
        if (m_hardModeEnabled)
        {
            AddScore(m_ScorePerPinHard);
        }
        else
        {
            AddScore(m_ScorePerPin);
        }
    } //for when a pin is knocked over and scored 

    #region Score Manipulation
    public void ScoreUpdated()
    {
        m_scoreUI.text = m_score.ToString();
    }
    public void AddScore(float Score)
    {
        if (m_isActive)
        {
            m_score += Score;
            ScoreUpdated();
        }
    }
    public void MinusScore(float Score)
    {
        if (m_isActive)
        {
            m_score -= Score;
            ScoreUpdated();
        }
    }
    public void SetScore(float Score)
    {
        m_score = Score;
        ScoreUpdated();
    }
    public float GetScore()
    {
        return m_score;
    }

    #endregion

    #region High Score Manipulation
    private void HighScoreUpdate()
    {
        m_highScoreUI.text = "Highscore: " + m_scoreUI.ToString();
    }
    public void CheckForNewHighScore()
    {
        if (m_score > m_highScore)
        {
            m_highScore = m_score;
            HighScoreUpdate();
        }
    }
    #endregion

    public void SetActive(bool Active)
    {
        m_isActive = Active;
    }

    public void ToggleHardMode(bool TorF)
    {
        m_hardModeEnabled = TorF;
    }
}
