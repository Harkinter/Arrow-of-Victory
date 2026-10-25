
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

[RequireComponent(typeof(Collider))]
public class Move : MonoBehaviour
{
    [SerializeField] private float moveAcceleration = 25f;
    [SerializeField] private float maxMoveSpeed = 5f;
    [SerializeField] private float groundFriction = 30f;
    [SerializeField] private float hoverHeight = 0.15f;
    [SerializeField] private float probeStartHeight = 0.25f;
    [SerializeField] private float probeDistance = 0.5f;
    [SerializeField] private float hoverStrength = 80f;
    [SerializeField] private float hoverDamping = 12f;
    [SerializeField] private LayerMask groundLayers = ~0;

    private Rigidbody body;
    private Collider bodyCollider;
    private Vector3 movementInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        bodyCollider = GetComponent<Collider>();
    }

    public void Movement(Vector3 dir)
    {
        dir.y = 0f;
        movementInput = Vector3.ClampMagnitude(dir, 1f);
    }

    private void FixedUpdate()
    {
        bool grounded = TryGetGround(out RaycastHit groundHit, out float targetDistance);

        if (grounded)
        {
            float distanceError = targetDistance - groundHit.distance;
            float verticalSpeed = Vector3.Dot(body.linearVelocity, Vector3.up);
            float hoverAcceleration = -Vector3.Dot(Physics.gravity, Vector3.up)
                + distanceError * hoverStrength
                - verticalSpeed * hoverDamping;
            body.AddForce(Vector3.up * hoverAcceleration, ForceMode.Acceleration);
        }

        Vector3 moveDirection = movementInput;
        if (grounded)
        {
            moveDirection = Vector3.ProjectOnPlane(moveDirection, groundHit.normal).normalized;
        }

        Vector3 horizontalVelocity = Vector3.ProjectOnPlane(body.linearVelocity, Vector3.up);
        if (moveDirection.sqrMagnitude > 0f)
        {
            Vector3 targetVelocity = moveDirection * maxMoveSpeed;
            Vector3 acceleration = (targetVelocity - horizontalVelocity) / Time.fixedDeltaTime;
            body.AddForce(Vector3.ClampMagnitude(acceleration, moveAcceleration), ForceMode.Acceleration);
        }
        else if (grounded && horizontalVelocity.sqrMagnitude > 0f)
        {
            body.AddForce(-horizontalVelocity * groundFriction, ForceMode.Acceleration);
        }
    }

    private bool TryGetGround(out RaycastHit hit, out float targetDistance)
    {
        Vector3 rayOrigin;
        float colliderHeight;

        if (bodyCollider != null)
        {
            Bounds bounds = bodyCollider.bounds;
            colliderHeight = bounds.size.y;
            rayOrigin = new Vector3(bounds.center.x, bounds.max.y + probeStartHeight, bounds.center.z);
        }
        else
        {
            colliderHeight = 0f;
            rayOrigin = body.position + Vector3.up * probeStartHeight;
        }

        targetDistance = colliderHeight + probeStartHeight + hoverHeight;
        float rayLength = targetDistance + probeDistance;
        RaycastHit[] hits = Physics.RaycastAll(rayOrigin, Vector3.down, rayLength, groundLayers, QueryTriggerInteraction.Ignore);

        float nearestDistance = float.PositiveInfinity;
        hit = default;
        bool foundGround = false;

        foreach (RaycastHit candidate in hits)
        {
            Transform hitTransform = candidate.collider.transform;
            if (hitTransform == transform || hitTransform.IsChildOf(transform))
            {
                continue;
            }

            if (candidate.distance < nearestDistance)
            {
                nearestDistance = candidate.distance;
                hit = candidate;
                foundGround = true;
            }
        }

        return foundGround;
    }
}