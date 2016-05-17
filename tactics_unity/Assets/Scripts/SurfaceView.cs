using UnityEngine;
using System.Collections;

public class SurfaceView : MonoBehaviour {
    public Material mselect;
    public Material mhilight;
    
    public State state;
    public enum State
    {
        Selected,
        Highlighted,
        Hidden
    }
    public void Start()
    {
        Hide();
    }

    public void Select()
    {
        state = State.Selected;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = mselect;
        meshRenderer.enabled = true;
    }

    public void Highlight()
    {
        state = State.Highlighted;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = mhilight;
        meshRenderer.enabled = true;
    }

    public void Hide()
    {
        state = State.Hidden;
        var meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
