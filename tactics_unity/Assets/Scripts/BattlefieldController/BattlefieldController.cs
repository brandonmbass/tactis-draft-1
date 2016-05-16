using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BattlefieldController : MonoBehaviour {
    public Battlefield battlefield;
    Stack<BattlefieldState> stack = new Stack<BattlefieldState>();

	// Use this for initialization
	void Start () {
        PushState<OpenState>();
    }

    internal void PopState()
    {
        State.OnExit();
        stack.Pop();
        State.OnEnter();
    }
    public void PushState<T>() where T : BattlefieldState
    {
        var state = (T)Activator.CreateInstance(typeof(T), battlefield, this);

        if (State != null)
        {
            State.OnExit();
        }

        stack.Push(state);
        State.OnEnter();
    }

    public BattlefieldState State
    {
        get
        {
            return stack.Count > 0 ? stack.Peek() : null;
        }        
    }

    // Update is called once per frame
    void Update () {
        State.OnUpdate();
	}
}