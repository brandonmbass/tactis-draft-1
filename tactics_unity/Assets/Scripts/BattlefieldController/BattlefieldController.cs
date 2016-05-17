using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BattlefieldController : MonoBehaviour {
    public Battlefield Battlefield;

    Stack<BattlefieldState> m_battlefieldStates = new Stack<BattlefieldState>();

	// Use this for initialization
	void Start () {
        PushState<OpenState>();
    }

    internal void PopState()
    {
        State.OnExit();
        m_battlefieldStates.Pop();
        State.OnEnter();
    }
    public void PushState<T>() where T : BattlefieldState
    {
        var state = (T)Activator.CreateInstance(typeof(T), Battlefield, this);

        if (State != null)
        {
            State.OnExit();
        }

        m_battlefieldStates.Push(state);
        State.OnEnter();
    }
    
    public BattlefieldState State
    {
        get
        {
            return m_battlefieldStates.Count > 0 ? m_battlefieldStates.Peek() : null;
        }        
    }

    // Update is called once per frame
    void Update () {
        State.OnUpdate();
	}

    public void ButtonPress(String name){ State.Interact(Interaction.MouseClick, name, transform); }
    public void Interact(Interaction interaction, Surface transform) { State.Interact(interaction, transform); }
    public void Interact(Interaction interaction, Unit transform) { State.Interact(interaction, transform); }
}

public enum Interaction
{
    MouseEnter,
    MouseExit,
    MouseDown,
    MouseUp,
    MouseOver,
    MouseClick
}