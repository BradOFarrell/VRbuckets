using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ForceDrop : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private ColorSync _colorSync;

    void Awake()
    {
        grabInteractable = GetComponentInParent<XRGrabInteractable>();
        _colorSync = GetComponent<ColorSync>();
    }
    public void Drop()
    {
        if (grabInteractable.isSelected)
        {
            var interactor = grabInteractable.firstInteractorSelecting;
            if (interactor != null)
            {
                grabInteractable.interactionManager.SelectExit(interactor, grabInteractable);
            }
        }
    }
}
