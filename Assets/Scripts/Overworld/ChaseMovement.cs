using UnityEngine;

public class ChaseMovement : EnemyMovement
{
    public override void Move(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }
}