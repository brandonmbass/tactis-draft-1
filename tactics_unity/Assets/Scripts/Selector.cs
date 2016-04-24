using UnityEngine;
using System.Collections;
using System;

public class Selector : MonoBehaviour {
    enum State {
        OPEN
    }

    State state;
    Surface selectedSurface;
	
    internal void surfaceClick( Surface clickedSurface)
    {
        if (selectedSurface != null)
            selectedSurface.GetComponentInChildren<SurfaceIndicator>().hide();
                
        selectedSurface = clickedSurface;
        selectedSurface.GetComponentInChildren<SurfaceIndicator>().select();
    }

    internal void surfaceMouseEnter(Surface surface)
    {
        var indicator = surface.GetComponentInChildren<SurfaceIndicator>();
        if (indicator.state != SurfaceIndicator.State.SELECTED)
            indicator.hilight();
    }

    internal void surfaceMouseExit(Surface surface)
    {
        var indicator = surface.GetComponentInChildren<SurfaceIndicator>();
        if (indicator.state != SurfaceIndicator.State.SELECTED)
            indicator.hide();
    }
}
