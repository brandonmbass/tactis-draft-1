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

    public virtual void MouseEnter(Transform transform) { }
    public virtual void MouseExit(Transform transform) { }
    public virtual void MouseDown(Transform transform) { }
    public virtual void MouseOver(Transform transform) { }
    public virtual void MouseUp(Transform transform) { }
    public virtual void MouseClick(Transform transform) { }

    internal abstract void OnExit();
    internal abstract void OnUpdate();
    internal abstract void OnEnter();
}
