using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class IgnoreCollisionWithSocket : MonoBehaviour
{
    XRSocketInteractor _socket;

    [SerializeField]
    Collider _ourColldier = null;
    Collider _theirColldier;


    private void Awake()
    {
        _socket = GetComponent<XRSocketInteractor>();
        Assert.IsNotNull( _socket );

        if (_ourColldier == null)
        {
            _ourColldier.GetComponent<Collider>();
        }

        _socket.selectEntered.AddListener(OnSelectEntered);
        _socket.selectExited.AddListener(OnSelectExited);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject other = args.interactableObject.transform.gameObject;
        _theirColldier = other.GetComponent<Collider>();

        //ignore 
        Physics.IgnoreCollision(_ourColldier, _theirColldier, true);
    }

    void OnSelectExited(SelectExitEventArgs args)
    {
        //ignore off
        Physics.IgnoreCollision(_ourColldier, _theirColldier, false);
    }
}
