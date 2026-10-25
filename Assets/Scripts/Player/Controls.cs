using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    // Required components
    public Move move;

    // Private values
    private InputSystem_Actions input; // The entire input system
    private void Start()
    {
        input = new();
        input.Enable();
    }
    private void Update()
    {
        Vector2 moveDir = input.Player.Move.ReadValue<Vector2>();
        move.Movement(new Vector3(moveDir.x, 0, moveDir.y));
    }
}
