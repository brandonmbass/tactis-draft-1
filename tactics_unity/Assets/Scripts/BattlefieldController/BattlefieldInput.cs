using UnityEngine;
using System.Collections;

public class BattlefieldInput : MonoBehaviour {
    BattlefieldController battlefieldController;
    Surface surface;

    void Start()
    {
        battlefieldController = FindObjectOfType<BattlefieldController>();
        surface = gameObject.GetComponent<Surface>();
    }
    
    void OnMouseEnter()
    {
        battlefieldController.Interact(Interaction.MouseEnter, surface);
    }

    void OnMouseExit()
    {
        battlefieldController.Interact(Interaction.MouseExit, surface);
    }

    void OnMouseDown()
    {
        battlefieldController.Interact(Interaction.MouseDown, surface);
    }

    void OnMouseUp()
    {
        battlefieldController.Interact(Interaction.MouseUp, surface);
    }

    void OnMouseOver()
    {
        battlefieldController.Interact(Interaction.MouseOver, surface);
    }

    void OnMouseClick()
    {
        battlefieldController.Interact(Interaction.MouseClick, surface);
    }
}
