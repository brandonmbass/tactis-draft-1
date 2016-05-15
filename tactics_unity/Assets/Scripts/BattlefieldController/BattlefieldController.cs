using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BattlefieldController : MonoBehaviour {
    BattlefieldState state;
    Dictionary<Type, BattlefieldState> states = new Dictionary<Type, BattlefieldState>()
    {
        {typeof(OpenState), new OpenState()}
    };

	// Use this for initialization
	void Start () {
        state = states[typeof(OpenState)];
	}

    public BattlefieldState GetState()
    {
        return state;
    }

    public void SetState(BattlefieldState state)
    {
        this.state = state;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void SetState()
    {

    }
}