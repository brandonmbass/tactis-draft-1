using UnityEngine;
using System.Collections;
using System;

public class OpenState : BattlefieldState {
    SurfaceSelector surfaceSelector = new SurfaceSelector();
    public OpenState(Battlefield battlefield, BattlefieldController controller) : base(battlefield, controller) { }

    public override void MouseDown(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
        {
            surfaceSelector.SurfaceMouseDown(surface);
        }
    }

    public override void MouseEnter(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
            surfaceSelector.Enter(surface);
    }

    public override void MouseExit(Transform transform)
    {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
            surfaceSelector.Exit(surface);
    }

    internal override void OnEnter()
    {
        
    }

    internal override void OnExit()
    {
        surfaceSelector.clear();
    }

    internal override void OnUpdate()
    {
        
    }
}
