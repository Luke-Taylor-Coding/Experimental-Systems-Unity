using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;

// GUN
// shoot on trigger press
// must shoot objects with a genourous cooldown to keep up with balloons
// use a bullet pool

public class GunManager : MonoBehaviour
{

    public XRGrabInteractable m_grabInteractable;
    private XRBaseInputInteractor m_interactor;
    private bool m_isHeld = false;
    [SerializeField] private InputActionReference m_triggerActionR;
    [SerializeField] private InputActionReference m_triggerActionL;

    [SerializeField] private GameObject[] m_bulletPool;
    [SerializeField] private Transform m_firePoint;

    [SerializeField] private float m_cooldownTime = 0.5f;
    private float m_timer = 0f;

    #region Determine if gun is held and trigger is pressed
    private void OnEnable()
    {
        m_grabInteractable.selectEntered.AddListener(OnSelectEntered);
        m_grabInteractable.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        m_grabInteractable.selectEntered.RemoveListener(OnSelectEntered);
        m_grabInteractable.selectExited.RemoveListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        m_interactor = args.interactorObject as XRBaseInputInteractor;
        m_isHeld = true;
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        m_interactor = null;
        m_isHeld = false;
    }
    #endregion

    void Update()
    {
        //add cooldown timer to shooting
        m_timer += Time.deltaTime;
        if (m_timer >= m_cooldownTime)
        {
            //if held and trigger pressed fire
            if (m_isHeld && m_interactor != null)
            {
                if (m_triggerActionR.action.ReadValue<float>() > 0.9f || m_triggerActionL.action.ReadValue<float>() > 0.9f)
                {
                    FireBullet();
                    m_timer = 0f;
                }
            }
        }
    }

    private void FireBullet()
    {
        //grab an inactive bullet from the pool
        foreach (var bullet in m_bulletPool)
        {
            if (bullet.activeSelf)
            {
                continue;
            }
            else
            {
                //set its position to be the fire point  
                bullet.transform.position = m_firePoint.position;
                //set its rotation with -90 degrees on the Y-axis  
                bullet.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.eulerAngles.x, gameObject.transform.rotation.eulerAngles.y - 90, gameObject.transform.rotation.eulerAngles.z);
                //fire it  
                bullet.SetActive(true);
                bullet.GetComponent<BulletScript>().Fire(m_firePoint.forward);
                return;
            }
        }

        //haptic feedback?
    }
}
