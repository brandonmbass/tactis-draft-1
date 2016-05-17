using UnityEngine;
using System.Collections;

public class SurfaceSelector {
    Surface selectedSurface;
    public void SurfaceMouseDown(Surface surface)
    {
        if (selectedSurface != null)
            selectedSurface.GetComponent<SurfaceView>().Hide();

        selectedSurface = surface;
        selectedSurface.GetComponent<SurfaceView>().Select();
    }

    public void Enter(Surface surface)
    {
        var view = surface.GetComponent<SurfaceView>();
        if (view.state != SurfaceView.State.Selected)
            view.Highlight();
    }

    public void Exit(Surface surface)
    {
        var view = surface.GetComponent<SurfaceView>();
        if (view.state != SurfaceView.State.Selected)
            view.Hide();
    }

    public void clear()
    {
        if (selectedSurface == null)
        {
            return;
        }

        var view = selectedSurface.GetComponent<SurfaceView>();
        view.Hide();
        selectedSurface = null;
    }
}
