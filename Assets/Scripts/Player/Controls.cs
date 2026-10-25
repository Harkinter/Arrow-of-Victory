using UnityEngine;

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
        Vector2 dir = input.Player.Move.ReadValue<Vector2>().normalized;
        move.Movement(new Vector3(dir.x, 0, dir.y));
    }
}
