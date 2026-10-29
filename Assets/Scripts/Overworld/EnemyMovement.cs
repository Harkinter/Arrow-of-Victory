using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Move(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}