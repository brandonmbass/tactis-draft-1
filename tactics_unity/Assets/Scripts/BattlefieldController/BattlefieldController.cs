using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BattlefieldController : MonoBehaviour {
    public Battlefield battlefield;
    BattlefieldState state;
    Dictionary<Type, BattlefieldState> states;
    Stack<BattlefieldState> stack = new Stack<BattlefieldState>();

    
    // Use this for initialization
    void Start () {
        states = new Dictionary<Type, BattlefieldState>() {
            {typeof(OpenState), new OpenState(battlefield, this)},
            {typeof(UnitAdderState), new UnitAdderState(battlefield, this)}
        };
        state = states[typeof(UnitAdderState)];
    }

    internal void PopState()
    {
        if (stack.Count > 0)
        {
            state = stack.Pop();
        }
        else
        {
            state = states[typeof(UnitAdderState)];
        }
    }
    public void PushState(Type new_state)
    {
        stack.Push(state);
        state = states[new_state];
    }

    public BattlefieldState GetState()
    {
        return state;
    }

    public void SetState(Type new_state)
    {
        state.OnExit();
        state = states[new_state];
        state.OnEnter();
    }

    // Update is called once per frame
    void Update () {
        state.OnUpdate();
	}

    public void ButtonPress(String name){ state.Interact(Interaction.MOUSE_CLICK, name, transform); }
    public void Interact(Interaction interaction, Surface transform) { state.Interact(interaction, transform); }
    public void Interact(Interaction interaction, Unit transform) { state.Interact(interaction, transform); }
}

public enum Interaction
{
    MOUSE_ENTER,
    MOUSE_EXIT,
    MOUSE_DOWN,
    MOUSE_UP,
    MOUSE_OVER,
    MOUSE_CLICK
}