using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] [Range(0, 15)]
    private float baseSpeed = 10f;

    private float currentSpeed = 0f;

    private Vector3 baseDestination = Vector3.zero;
    private Vector3 currentDestination = Vector3.zero;
    private new Rigidbody rigidbody = null;
    private Prober probe = null;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        probe = GetComponentInChildren<Prober>();
    }

    private void Start()
    {
        probe.AddTileListener(ApplyTileModifier);

        currentSpeed = baseSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 trip = currentDestination - transform.position;

        if (trip.magnitude > float.Epsilon)
        {
            Vector3 direction = trip.normalized;
            rigidbody.MovePosition(transform.position + Vector3.ClampMagnitude(direction * currentSpeed * Time.fixedDeltaTime, trip.magnitude));
            //transform.LookAt(destination);
        }
    }

    public void MoveTo(Vector3 point)
    {
        baseDestination = new Vector3(point.x, 0, point.z);
        currentDestination = baseDestination;
    }

    private void ApplyTileModifier(Tile tile)
    {
        currentSpeed = tile.ApplySpeedModifier(baseSpeed, transform.position, baseDestination, out currentDestination);
    }

    public float Speed { get => currentSpeed; }
}
