using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BattlefieldController : MonoBehaviour {
    public Battlefield battlefield;
    BattlefieldState state;
    Dictionary<String, BattlefieldState> states;
    Stack<BattlefieldState> stack = new Stack<BattlefieldState>();

	// Use this for initialization
	void Start () {
        states = new Dictionary<String, BattlefieldState>() {
            {"OPEN", new OpenState(battlefield, this)},
            {"UNIT_ADDER", new UnitAdderState(battlefield, this)}
        };
        state = states["OPEN"];
    }

    internal void PopState()
    {
        if (stack.Count > 0)
        {
            state = stack.Pop();
        }
        else
        {
            state = states["OPEN"];
        }
    }
    public void PushState(String state_name)
    {
        stack.Push(state);
        state = states[state_name];
    }

    public BattlefieldState GetState()
    {
        return state;
    }

    public void SetState(string state_name)
    {
        state.OnExit();
        state = states[state_name];
        state.OnEnter();
    }

    // Update is called once per frame
    void Update () {
        state.OnUpdate();
	}
}