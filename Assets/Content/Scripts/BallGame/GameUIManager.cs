using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI m_gameUI = null;

    public string StartText = null;
    public string GameBeginText = null;
    public string GameEndText = null;

    void Start()
    {
        m_gameUI.text = StartText;
    }

    public void StartingText()
    {
        m_gameUI.text = StartText;
    }

    public void GameStart()
    {
        m_gameUI.text = GameBeginText;
    }

    public void GameEnd()
    {
        m_gameUI.text = GameEndText;
    }
    
}
