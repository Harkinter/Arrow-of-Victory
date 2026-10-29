using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    protected Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Flip()
    {
        if (rb.linearVelocity.x < -0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (rb.linearVelocity.x > 0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    void Update()
    {
        Flip();
    }

    public virtual void Move(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}