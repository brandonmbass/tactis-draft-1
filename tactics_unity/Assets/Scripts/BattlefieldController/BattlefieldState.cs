using UnityEngine;
using System.Collections;
using System;

public abstract class BattlefieldState {
    protected Battlefield battlefield;
    protected BattlefieldController controller;

    public BattlefieldState(Battlefield battlefield, BattlefieldController controller)
    {
        this.battlefield = battlefield;
        this.controller = controller;
    }
    
    public virtual void Interact(Interaction interaction, Surface transform) { }
    public virtual void Interact(Interaction interaction, Unit transform) { }
    public virtual void Interact(Interaction interaction, String buttonName, Transform transform) { }

    internal virtual void OnExit() { }
    internal virtual void OnUpdate() { }
    internal virtual void OnEnter() { }
}
