using System;
using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// Basic character controller based on "CharacterController" component
/// </summary>
public class Move : MonoBehaviour
{
    // Modifiers
    public float speed; // Defines speed of movement
    public float gravity; // Defines rate of falling

    // Component dependencies
    public CharacterController character;

    // Variables
    private float gravityAcceleration; // Rate of falling increases while remaining ungrounded

    private void Update()
    {
        character.Move(speed * Time.deltaTime * Vector3.right);
        if (character.isGrounded) 
        { 
            gravityAcceleration = 1f;
        }
        if (!character.isGrounded) 
        { 
            character.Move(gravity * gravityAcceleration * Time.deltaTime * Vector3.down);
            gravityAcceleration += 0.1f;
        }
    }
}
