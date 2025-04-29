using UnityEngine;
using UnityEditor;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private bool m_isActive = false;
    private float m_score = 0;
    public TextMeshProUGUI[] m_scoreUIs = null;

    public void ScoreUpdated()
    {
        foreach (var UI in m_scoreUIs)
        {
            UI.text = m_score.ToString();
        }
    }

    #region Score Manipulation
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
    #endregion

    public float GetScore()
    {
        return m_score;
    }

    public void SetActive(bool Active)
    {
        m_isActive = Active;
    }

}
