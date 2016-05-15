using UnityEngine;
using System.Collections;
using System;

public class OpenState : BattlefieldState {
    Surface selectedSurface;

    public override void MouseDown(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
            SurfaceMouseDown(surface);
    }

    public override void MouseEnter(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
            SurfaceMouseEnter(surface);
    }

    public override void MouseExit(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
            SurfaceMouseExit(surface);
    }

    internal void SurfaceMouseDown(Surface surface)
    {
        if (selectedSurface != null)
            selectedSurface.GetComponentInChildren<SurfaceIndicator>().hide();
                
        selectedSurface = surface;
        selectedSurface.GetComponentInChildren<SurfaceIndicator>().select();
    }

    internal void SurfaceMouseEnter(Surface surface)
    {
        var indicator = surface.GetComponentInChildren<SurfaceIndicator>();
        if (indicator.state != SurfaceIndicator.State.SELECTED)
            indicator.hilight();
    }

    internal void SurfaceMouseExit(Surface surface)
    {
        var indicator = surface.GetComponentInChildren<SurfaceIndicator>();
        if (indicator.state != SurfaceIndicator.State.SELECTED)
            indicator.hide();
    }
}
