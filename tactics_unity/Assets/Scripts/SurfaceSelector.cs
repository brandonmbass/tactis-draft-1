using UnityEngine;
using System.Collections;

public class SurfaceSelector {
    Surface selectedSurface;
    public void SurfaceMouseDown(Surface surface)
    {
        if (selectedSurface != null)
            selectedSurface.GetComponent<SurfaceView>().hide();

        selectedSurface = surface;
        selectedSurface.GetComponent<SurfaceView>().select();
    }

    public void Enter(Surface surface)
    {
        var view = surface.GetComponent<SurfaceView>();
        if (view.state != SurfaceView.State.SELECTED)
            view.hilight();
    }

    public void Exit(Surface surface)
    {
        var view = surface.GetComponent<SurfaceView>();
        if (view.state != SurfaceView.State.SELECTED)
            view.hide();
    }

    public void clear()
    {
        var view = selectedSurface.GetComponent<SurfaceView>();
        view.hide();
        selectedSurface = null;
    }
}
