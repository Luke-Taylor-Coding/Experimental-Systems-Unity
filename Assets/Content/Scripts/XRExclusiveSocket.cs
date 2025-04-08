using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRExclusiveSocket : XRSocketInteractor
{
    [SerializeField]
    string _acceptedTag;

    //generate visual mesh if true
    public override bool CanHover(IXRHoverInteractable interactable)
    {
        if (!base.CanHover(interactable))
        {
            return false;
        }
        if (interactable.transform.tag == _acceptedTag)
        {
            return true;
        }

        return false;
    }

    //attaches object to socket if true
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        if (!base.CanSelect(interactable))
        {
            return false;
        }
        if (interactable.transform.tag == _acceptedTag)
        {
            return true;
        }

        return false;
    }

}
