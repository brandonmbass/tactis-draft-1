using UnityEngine;
using System.Collections;

public class BattlefieldInput : MonoBehaviour {
    BattlefieldController battlefieldController;

    void Start()
    {
        battlefieldController = FindObjectOfType<BattlefieldController>();
    }
    
    void OnMouseEnter() { battlefieldController.GetState().MouseEnter(transform); }

    void OnMouseExit() { battlefieldController.GetState().MouseExit(transform); }

    void OnMouseDown() { battlefieldController.GetState().MouseDown(transform); }

    void OnMouseUp() { battlefieldController.GetState().MouseUp(transform); }

    void OnMouseOver() { battlefieldController.GetState().MouseOver(transform); }

    void OnMouseClick() { battlefieldController.GetState().MouseClick(transform); }
}
