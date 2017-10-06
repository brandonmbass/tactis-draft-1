using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : GlobalBehavior {
    
	void Start () {
	    InputManager.KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.O))
            {
                UIManager.ToggleCraftingDialog();
            }

            return args;
        });
    }
}
