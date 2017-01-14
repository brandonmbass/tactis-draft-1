using UnityEngine;
using System.Collections;
using System;

public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual void Interact()
    {
        Debug.Log("interact!");
    }
}
