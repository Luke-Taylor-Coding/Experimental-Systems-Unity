using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class PreventGunLoss : XRBaseInteractable
{
    protected override void OnEnable()
    {
        base.OnEnable();
        selectExited.AddListener(EndGrab);
    }
    void EndGrab(SelectExitEventArgs args)
    {
        //reset gun position if it is dropped
        if (!isSelected)
        {
            // Reset the gun position to its original position
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }   
    }
}
