using System.Collections;
using UnityEngine;

// BALLOON SPAWNER
// balloon pool
// hold several spawning positions for ballons around area
// have timer for when balloons are spawned
// spawn randomly between positions
// decrease spawn timer based on active game time 

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] m_BallonPool;
    public Transform[] m_spawnPoints;

    [SerializeField] float m_spawnTime = 7.5f; //seconds

    private bool m_isActive = true;
    private Coroutine m_balloonCooldown;

    private void FixedUpdate()
    {
        if (!m_isActive)
        {
            return;
        }

        // check if timer to spawn balloon has ended
        if (m_balloonCooldown == null)
        {
            m_balloonCooldown = StartCoroutine(BalloonCooldown());
        }
    }
    private void SpawnBalloon()
    {
        foreach (var item in m_BallonPool)
        {
            //find in-active
            if (item.activeSelf)
            {
                continue;
            }
            else
            {
                //set the transform pos of the balloon to a random spawn point
                item.transform.position = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)].position;  

                //set to active
                item.SetActive(true);
                return;
            }
        }
    }
    IEnumerator BalloonCooldown()
    {
        // starts a cooldown
        yield return new WaitForSeconds(m_spawnTime);

        //reset cooldown
        m_balloonCooldown = null;

        //spawns a balloon
        SpawnBalloon();
    }
    public void SetActive(bool TorF)
    {
        //force stop coroutine
        StopCoroutine(m_balloonCooldown);

        if (TorF)
        {
            m_isActive = true;
        }
        else 
        {
            //ensure all balloons are deactivated
            foreach (var item in m_BallonPool)
            {
                item.SetActive(false);
            }

            m_isActive = false;
        }
    }
}
