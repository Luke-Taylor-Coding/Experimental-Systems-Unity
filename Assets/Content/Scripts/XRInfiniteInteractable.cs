using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRInfiniteInteractable : MonoBehaviour
{

    [SerializeField]
    XRBaseInteractable m_interatablePrefab;

    XRBaseInteractor m_socket;

    private void Awake()
    {
        m_socket = GetComponent<XRBaseInteractor>();
        Assert.IsNotNull(m_socket);
    }

    private void OnEnable()
    {
        m_socket.selectExited.AddListener(OnSelectExited);
    }

    private void OnDisable()
    {
        m_socket.selectExited.RemoveListener(OnSelectExited); 
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        Transform socketTransform = m_socket.transform;
        XRBaseInteractable interactable = Instantiate(m_interatablePrefab, socketTransform.position, socketTransform.rotation);

        m_socket.interactionManager.SelectEnter((IXRSelectInteractor)m_socket, interactable);
    }
}
