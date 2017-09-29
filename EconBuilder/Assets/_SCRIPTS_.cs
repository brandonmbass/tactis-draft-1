using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SCRIPTS_ : MonoBehaviour {

    static _SCRIPTS_ Instance;
	// Use this for initialization
	void Start () {
        if (Instance != null)
        {
            GameObject.DestroyObject(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    	
	// Update is called once per frame
	void Update () {
		
	}
}
