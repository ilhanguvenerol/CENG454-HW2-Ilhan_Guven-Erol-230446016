using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        // TODO (Task 3-E): cache the aircraft transform 
        target = newTarget;
    }

    void Update()
    {
        if (target == null) return;
        // TODO (Task 3-F): rotate toward the target and move forward 
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                desiredRotation,
                turnSpeed * Time.deltaTime
            );
        }

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
