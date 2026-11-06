using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Move _move;
    public Transform _player;

    private void FixedUpdate()
    {
        _move.Movement((_player.position - transform.position).normalized);
    }

}