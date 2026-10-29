using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMovement movement;
    public Transform player;

    private void FixedUpdate()
    {
        movement.Move(player);
    }

}