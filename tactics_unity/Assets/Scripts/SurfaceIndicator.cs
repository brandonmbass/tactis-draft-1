using UnityEngine;
using System.Collections;

public class SurfaceIndicator : MonoBehaviour {
    public Material mselect;
    public Material mhilight;
    
    public State state;
    public enum State
    {
        SELECTED,
        HIGLIGHTED,
        HIDDEN
    }
    public void Start()
    {
        hide();
    }

    public void select()
    {
        state = State.SELECTED;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = mselect;
        meshRenderer.enabled = true;
    }

    public void hilight()
    {
        state = State.HIGLIGHTED;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = mhilight;
        meshRenderer.enabled = true;
    }

    public void hide()
    {
        state = State.HIDDEN;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
