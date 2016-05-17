using UnityEngine;
using System.Collections;
using System;

public class UnitAdderState : BattlefieldState {
    public UnitAdderState(Battlefield battlefield, BattlefieldController controller) : base(battlefield, controller) { }
    SurfaceSelector surfaceSelector = new SurfaceSelector();
    
    public override void Interact(Interaction interaction, Surface surface)
    {
        switch (interaction)
        {
            case Interaction.MOUSE_DOWN:
                battlefield.CreateUnit(surface);
                controller.PopState();
                break;
            case Interaction.MOUSE_ENTER:
                surfaceSelector.Enter(surface);
                break;
            case Interaction.MOUSE_EXIT:
                surfaceSelector.Exit(surface);
                break;
        }
    }

    internal override void OnExit()
    {
        surfaceSelector.clear();
    }
}
