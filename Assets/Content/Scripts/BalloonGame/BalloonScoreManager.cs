using TMPro;
using UnityEngine;

public class BalloonScoreManager : MonoBehaviour
{
    private bool m_isActive = false;
    private float m_score = 0;
    public float m_ScorePerBalloon = 100;
    public TextMeshProUGUI m_scoreUI = null;

    public void BalloonScored()
    {
        AddScore(m_ScorePerBalloon);
    } 

    #region Score Manipulation
    public void ScoreUpdated()
    {
        m_scoreUI.text = "Score: " + m_score.ToString();
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

    public void SetActive(bool Active)
    {
        m_isActive = Active;
    }
}
