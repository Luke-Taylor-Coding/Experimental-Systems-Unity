using System.Collections;
using UnityEngine;

public class BallGameManager : MonoBehaviour
{
    //Manager class for the ball game

    private bool m_gameActive = false;
    public ScoreManager m_scoreManager;

    //list of all pins and stands they are on for activating 
    public GameObject[] m_pins;

    public float m_gameTime = 0;
    private IEnumerator m_gameTimeCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set inactive by defualt
        SetGameInactive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameActive()
    {
        m_gameActive = true;

        //set score manager to running, set score to 0
        m_scoreManager.SetActive(true);
        m_scoreManager.SetScore(0);

        //show and activate pins
        foreach (var pin in m_pins) 
        {
            pin.gameObject.SetActive(true);
        }

        //start coroutine for game time 
        m_gameTimeCoroutine = GameTimeCounter(m_gameTime);
        StartCoroutine(m_gameTimeCoroutine);

    }

    public void SetGameInactive()
    {
        m_gameActive = false;

        //stop coroutine if game stopped from other meathods 
        StopCoroutine(m_gameTimeCoroutine);

        //stop score manager
        m_scoreManager.SetActive(false);

        //de-activate and hide pins
        foreach (var pin in m_pins)
        {
            pin.gameObject.SetActive(false);
        }
    }

    IEnumerator GameTimeCounter(float time)
    {
        //waits for the game to end 
        yield return new WaitForSeconds(time);
        SetGameInactive();
    }
}
