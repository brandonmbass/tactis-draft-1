using UnityEngine;
using System.Collections;
using System;

public class OpenState : BattlefieldState {
    SurfaceSelector surfaceSelector = new SurfaceSelector();
    public OpenState(Battlefield battlefield, BattlefieldController controller) : base(battlefield, controller) { }

    public override void Interact(Interaction interaction, string name, Transform transform)
    {
        switch (name)
        {
            case "ADD_UNIT":
                controller.PushState(typeof(UnitAdderState));
                break;
        }
    }

    public override void Interact(Interaction interaction, Surface surface)
    {
        switch (interaction)
        {
            case Interaction.MOUSE_DOWN:
                surfaceSelector.SurfaceMouseDown(surface);
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
