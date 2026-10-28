using UnityEngine;

[RequireComponent(typeof(Move))]
public class Controls : MonoBehaviour
{
    // Required components
    private Move move;

    // Private values
    private InputSystem_Actions input; // The entire input system
    private void Awake()
    {
        input = new();
        input.Enable();
        move = GetComponent<Move>();
    }
    private void Update()
    {
        Vector2 dir = input.Player.Move.ReadValue<Vector2>().normalized;
        move.Movement(new Vector3(dir.x, 0, dir.y));
    }
}
