using UnityEngine;

public class FallDirectionDetector : MonoBehaviour
{
    public LayerMask wallLayer;     // Assign wall layer here (Optional: can be Default if maze walls use Default)
    public float maxRayDistance = 100f;

    public bool fallLeft;           // Result: true = Left, false = Right

    public void DetermineFallDirection()
    {
        float leftDistance = CastDirection(-transform.right);
        float rightDistance = CastDirection(transform.right);

        Debug.Log($"Left Distance: {leftDistance}, Right Distance: {rightDistance}");

        if (Mathf.Approximately(leftDistance, rightDistance))
        {
            // Equal distance  Random side
            fallLeft = (Random.value > 0.5f);
        }
        else
        {
            // Choose the side with MORE space (further wall)
            fallLeft = leftDistance > rightDistance;
        }
    }

    float CastDirection(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, maxRayDistance, wallLayer))
        {
            return hit.distance;
        }
        return maxRayDistance; // No wall detected = treat as max
    }

    void OnDrawGizmosSelected()
    {
        // For debugging in Scene View
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right * 5f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.right * 5f);
    }
}
