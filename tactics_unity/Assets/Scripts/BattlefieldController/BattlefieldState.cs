using UnityEngine;
using System.Collections;
using System;

public abstract class BattlefieldState {
    public virtual void MouseEnter(Transform transform) { }
    public virtual void MouseExit(Transform transform) { }
    public virtual void MouseDown(Transform transform) { }
    public virtual void MouseOver(Transform transform) { }
    public virtual void MouseUp(Transform transform) { }
    public virtual void MouseClick(Transform transform) { }
}
