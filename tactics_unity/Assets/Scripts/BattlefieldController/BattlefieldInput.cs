using UnityEngine;
using System.Collections;

public class BattlefieldInput : MonoBehaviour {
    BattlefieldController battlefieldController;

    void Start()
    {
        battlefieldController = FindObjectOfType<BattlefieldController>();
    }
    
    void OnMouseEnter() { battlefieldController.State.MouseEnter(transform); }

    void OnMouseExit() { battlefieldController.State.MouseExit(transform); }

    void OnMouseDown() { battlefieldController.State.MouseDown(transform); }

    void OnMouseUp() { battlefieldController.State.MouseUp(transform); }

    void OnMouseOver() { battlefieldController.State.MouseOver(transform); }

    void OnMouseClick() { battlefieldController.State.MouseClick(transform); }
}
