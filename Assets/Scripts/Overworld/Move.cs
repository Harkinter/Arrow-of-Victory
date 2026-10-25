using UnityEngine;
using UnityEngine.InputSystem;

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

    public void Movement(Vector3 direction)
    {
        // Move the character by vertical and horizontal input
        character.Move(speed * Time.deltaTime * direction);
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
