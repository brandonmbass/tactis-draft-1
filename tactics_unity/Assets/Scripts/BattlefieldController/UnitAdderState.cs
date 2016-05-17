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
            case Interaction.MouseDown:
                battlefield.CreateUnit(surface);
                controller.PopState();
                break;
            case Interaction.MouseEnter:
                surfaceSelector.Enter(surface);
                break;
            case Interaction.MouseExit:
                surfaceSelector.Exit(surface);
                break;
        }
    }

    internal override void OnExit()
    {
        surfaceSelector.clear();
    }
}
