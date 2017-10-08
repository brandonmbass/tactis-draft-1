using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

public class InputManager : GlobalBehavior {
    Vector3 MoveVector;
    public EconEvent KeyPressed;

    void Start () {
        KeyPressed = new EconEvent();

        // TODO: move these to respective managers
        KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.B))
            {
                BuildingManager.StartPlacingHouse();
            }

            return args.RemoveKeys(KeyCode.B);
        });

        KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.Q))
            {
                UserActionManager.Chop();
            }

            return args.RemoveKeys(KeyCode.Q);
        });

        KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.E))
            {
                UserActionManager.Interact();
            }

            return args.RemoveKeys(KeyCode.E);
        });

        KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.Escape))
            {
                //if (UIManager.Dialog.activeInHierarchy)
                //{
                //    // We have an active dialog - dismiss it
                //    UIManager.Dialog.SetActive(false);
                //}
                //else
                {
                    UIManager.ToggleSettingsDialog();
                }
            }

            return args.RemoveKeys(KeyCode.Escape);
        });

        KeyPressed.AddListener((args) =>
        {
            if (ChatManager.IsActive)
            {
                return args.ClearKeys();
            }

            return args;
        });

        KeyPressed.AddListener((args) =>
        {
            if (args.IsPressed(KeyCode.I))
            {
                UIManager.TogglePlayerInventory();
            }

            return args.RemoveKeys(KeyCode.I);
        });
    }
	
	void Update () {
        if (Input.anyKeyDown)
        {
            KeyPressed.Invoke();
        }

        HandleCharacterMovement();
    }

    void FixedUpdate()
    {
        HandleCharacterMovementFixed();
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
        CurrentCharacterModel.Move(MoveVector);
    }
}
