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
        //check for score manager
        if (m_scoreManager == null)
        {
            Debug.LogError("Score manager not attached to Ball Game Manager!");
        }

        //set inactive by defualt
        SetGameInactive();
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

            //reset positions 
            pin.GetComponent<HoldPositionAndRotation>().ResetPositionAndRotation();
        }

        //start coroutine for game time 
        m_gameTimeCoroutine = GameTimeCounter(m_gameTime);
        StartCoroutine(m_gameTimeCoroutine);
    }

    public void SetGameInactive()
    {
        m_gameActive = false;

        //stop coroutine if game stopped from other meathods 
        try
        {
            StopCoroutine(m_gameTimeCoroutine);
        }
        catch (System.Exception)
        {
            Debug.Log("Coroutine for game time already stopped");
        }

        //stop score manager
        m_scoreManager.SetActive(false);

        //de-activate and hide pins
        foreach (var pin in m_pins)
        {
            //stop velocity
            Rigidbody rb = pin.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

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
