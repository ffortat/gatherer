using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] [Range(-100, 100)]
    private float inwardSpeedPercentageModifier = 0f;
    [SerializeField] [Range(-100, 100)]
    private float outwardSpeedPercentageModifier = 0f;

    [SerializeField] [Range(0f, 1f)]
    private float overshootDuration = 0f;

    private static float overshootTimer = 0f;
    private static Vector3 overshotDestination = Vector3.zero;
    private static Vector3 overshootDirection = Vector3.zero;

    public float ApplySpeedModifier(float baseSpeed, Vector3 position, Vector3 destination, out Vector3 newDestination)
    {
        Vector3 distance = transform.position - position;
        Vector3 trip = destination - position;
        Vector3 direction = trip.normalized;
        Vector3 nextDistance = distance - direction;

        if (overshootDuration > 0f && overshootTimer <= 0f && 
            trip.magnitude < (direction * baseSpeed * Time.fixedDeltaTime).magnitude &&
            overshotDestination != destination)
        {
            overshootTimer = overshootDuration;
            overshotDestination = destination;
            overshootDirection = direction;
        }

        if (overshootTimer > 0f)
        {
            if (overshotDestination == destination)
            {
                overshootTimer -= Time.fixedDeltaTime;

                float newSpeed = baseSpeed * overshootTimer / overshootDuration;

                newDestination = position + overshootDirection * newSpeed * Time.fixedDeltaTime;
                return newSpeed;
            }
            else
            {
                ResetOvershoot();
                newDestination = destination;
            }
        }
        else if (overshotDestination == destination)
        {
            newDestination = position;
        }
        else
        {
            newDestination = destination;
        }


        if (distance.magnitude > nextDistance.magnitude)
        {
            return baseSpeed * (1 + inwardSpeedPercentageModifier / 100f);
        }
        else
        {
            return baseSpeed * (1 + outwardSpeedPercentageModifier / 100f);
        }
    }

    private static void ResetOvershoot()
    {
        overshootTimer = 0f;
        overshotDestination = Vector3.zero;
        overshootDirection = Vector3.zero;
    }
}
