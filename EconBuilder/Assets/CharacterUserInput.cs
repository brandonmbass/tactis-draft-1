﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Character))]
public class CharacterUserInput : MonoBehaviour
{
    private Character m_Character; // A reference to the ThirdPersonCharacter on the object
    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;


    private void Start()
    {
        // get the third person character ( this should never be null due to require component )
        m_Character = GetComponent<Character>();
    }


    private void Update()
    {
        // read inputs
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate move direction to pass to character
        m_Move = v * Vector3.forward + h * Vector3.right;
    }


    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        // pass all parameters to the character control script
        m_Character.Move(m_Move);
    }
}