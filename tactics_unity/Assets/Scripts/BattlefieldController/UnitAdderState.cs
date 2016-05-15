using UnityEngine;
using System.Collections;
using System;

public class UnitAdderState : BattlefieldState {
    public UnitAdderState(Battlefield battlefield, BattlefieldController controller) : base(battlefield, controller) { }
    SurfaceSelector surfaceSelector = new SurfaceSelector();

    public override void MouseDown(Transform transform) {
        Surface surface = transform.GetComponent<Surface>();
        if(surface != null)
        {
            battlefield.CreateUnit(surface);
        }

        controller.PopState();
    }

    public override void MouseExit(Transform transform) {
        Surface surface = transform.GetComponent<Surface>();
        if(surface != null)
        {
            surfaceSelector.Exit(surface);
        }
    }

    public override void MouseEnter(Transform transform) {
        Surface surface = transform.GetComponent<Surface>();
        if (surface != null)
        {
            surfaceSelector.Enter(surface);
        }
    }

    internal override void OnEnter()
    {
        
    }

    internal override void OnExit()
    {
        
    }

    internal override void OnUpdate()
    {
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
