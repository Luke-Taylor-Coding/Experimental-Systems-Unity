using UnityEngine;
using UnityEditor;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float m_score = 0;
    public TextMeshProUGUI[] m_scoreUIs = null;

    public void ScoreUpdated()
    {
        foreach (var UI in m_scoreUIs)
        {
            UI.text = m_score.ToString();
        }
    }
    public void AddScore(float Score)
    {
        m_score += Score;
        ScoreUpdated();
    }
    public void MinusScore(float Score)
    {
        m_score -= Score;
        ScoreUpdated();
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
}
