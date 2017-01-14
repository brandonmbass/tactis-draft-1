using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : GlobalBehavior {
    Vector3 MoveVector;

    void Start () {
        Init();
    }
	
	void Update () {
        HandleKeyPress();
    }

    void FixedUpdate()
    {
        HandleCharacterMovementFixed();
    }

    void HandleKeyPress()
    {
        if (ChatManager.IsActive)
        {
            return;
        }

        if (BuildingManager.isPlacing)
        {
            // Input handled by BuildingManager
            // TODO: pass to BuildingManager here, rather than relying on BuildingManager to use GetKeyDown
            return;
        }        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.ToggleSettingsDialog();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Use Q action
            UserActionManager.Chop();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // Use E action (interact)
            UserActionManager.Interact();
        }

        HandleCharacterMovement();
    }

    void HandleCharacterMovement()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate move direction to pass to character
        MoveVector = v * Vector3.forward + h * Vector3.right;
    }

    void HandleCharacterMovementFixed()
    {
        Character.Move(MoveVector);
    }
}
