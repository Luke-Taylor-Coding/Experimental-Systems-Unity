using System.Collections;
using UnityEngine;

public class BallGameManager : MonoBehaviour
{
    //Manager class for the ball game

    private bool m_gameActive = false;
    private bool m_hardModeActive = false;
    public ScoreManager m_scoreManager;
    public GameUIManager m_gameUIManager;
    public PinCollectionScript m_pinCollectionScript;

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

        //set starting text
        m_gameUIManager.StartingText();
    }

    public void SetGameActive()
    {
        //if game is currently running do nothing
        if (m_gameActive)
        {
            return;
        }

        m_gameActive = true;

        //set game text 
        m_gameUIManager.GameStart();

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

        //set game text 
        m_gameUIManager.GameEnd();

        //check for high score
        m_scoreManager.CheckForNewHighScore();
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

        //call to the collector to reset the pins hit
        m_pinCollectionScript.SetCurrentPinsHit(0);
    }

    IEnumerator GameTimeCounter(float time)
    {
        //waits for the game to end 
        yield return new WaitForSeconds(time);
        SetGameInactive();
    }

    public void RespawnPins()
    {
        //show and activate pins
        foreach (var pin in m_pins)
        {
            pin.gameObject.SetActive(true);

            //stop velocity
            Rigidbody rb = pin.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            //reset positions 
            pin.GetComponent<HoldPositionAndRotation>().ResetPositionAndRotation();
        }
    }

    public void ToggleHardmode(bool TorF)
    {
        m_hardModeActive = TorF;
        m_scoreManager.ToggleHardMode(TorF);
    }
}
