using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ColorSync : RealtimeComponent<ColorSyncModel>
{
    private MeshRenderer _meshRenderer;

    private Color _color = default;
    private Color _p1color = Color.red;
    private Color _p2color = Color.blue;
    private Color _errorColor = Color.yellow;
    private Color _unOwned = Color.black; // Should be overwritten on awake



    private void Awake()
    {
        ColorUtility.TryParseHtmlString("#FFAA17", out Color outputColor);
        _unOwned = outputColor;

        // Get a reference to the mesh renderer
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void OnRealtimeModelReplaced(ColorSyncModel previousModel, ColorSyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.colorDidChange -= ColorDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current mesh renderer color.
            if (currentModel.isFreshModel)
                currentModel.color = _meshRenderer.material.color;

            // Update the mesh render to match the new model
            UpdateMeshRendererColor();

            // Register for events so we'll know if the color changes later
            currentModel.colorDidChange += ColorDidChange;
        }
    }

    private void ColorDidChange(ColorSyncModel model, Color value)
    {
        // Update the mesh renderer
        UpdateMeshRendererColor();
    }

    private void UpdateMeshRendererColor()
    {
        // Get the color from the model and set it on the mesh renderer.
        _meshRenderer.material.color = model.color;
    }

    public void SetColor(Color color)
    {
        // Set the color on the model
        // This will fire the colorChanged event on the model, which will update the renderer for both the local player and all remote players.
        model.color = color;
    }

    public void UpdateOwnershipColor()
    {
        if (realtimeView.ownerIDInHierarchy == -1)
        {
            _color = _errorColor;
        }
        else
        {
            _color = (realtimeView.ownerIDInHierarchy % 2 == 0) ? _p1color : _p2color;
        }
        SetColor(_color);
    }

    public void ResetOwnershipColor()
    {
        SetColor(_unOwned);
    }

}