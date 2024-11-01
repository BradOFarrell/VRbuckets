using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Unity.VisualScripting;
using TMPro;

public class RequestOwnership : MonoBehaviour
{
    [SerializeField] private RealtimeView realtimeView;
    [SerializeField] private RealtimeTransform realtimeTransform;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;
    [SerializeField] private TextMeshPro _bonusDisplay;

    private Realtime realtime;
    private ColorSync _colorSync;
    private HoopTracker _hoopTracker;
    private uint _lastUserID;

    private void Awake()
    {
        // Get a reference to the color sync component
        _colorSync = GetComponent<ColorSync>();
        _hoopTracker = GetComponent<HoopTracker>();
        realtime = GetComponent<Realtime>();
    }

private void Update()
    {
        // If the color has changed (via the inspector), call SetColor on the color sync component.
    }
    private void OnEnable()
    {
        xRGrabInteractable.selectEntered.AddListener(RequestObjectOwnership);
    }

    private void RequestObjectOwnership(SelectEnterEventArgs args)
    {
        _bonusDisplay.text = "";
        realtimeView.RequestOwnership();
        realtimeTransform.RequestOwnership();
        _colorSync.UpdateOwnershipColor();
        _hoopTracker.ResetTriggers();
    }

    private void OnDisable()
    {
        xRGrabInteractable.selectEntered.RemoveListener(RequestObjectOwnership);
    }
}
