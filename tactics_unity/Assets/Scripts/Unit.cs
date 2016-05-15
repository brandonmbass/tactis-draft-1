using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    Surface current_surface;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetSurface(Surface surface)
    {
        current_surface = surface;
    }
}
