using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float shedOpenDistance = 2f;

    private const string tileTag = "Tile";
    private const string shedTag = "Shed";
    private int tileLayer = 0;
    private int shedLayer = 0;

    private Mover mover = null;
    private Carrier carrier = null;

    private UnityEvent<Shed> onShedClick = new UnityEvent<Shed>();

    private void Awake()
    {
        mover = GetComponentInChildren<Mover>();
        carrier = GetComponentInChildren<Carrier>();

        tileLayer = LayerMask.NameToLayer(tileTag);
        shedLayer = LayerMask.NameToLayer(shedTag);
    }

    private void Update()
    {
        RaycastHit hit;
        LayerMask tileAndShedMask = LayerMask.GetMask(tileTag, shedTag);

        if (Physics.Raycast(GetMouseRay(), out hit, tileAndShedMask))
        {
            if (Input.GetMouseButton(0))
            {
                if (hit.collider.gameObject.layer == tileLayer)
                {
                    mover.MoveTo(hit.point);
                }
                else if (hit.collider.gameObject.layer == shedLayer)
                {
                    Vector3 shedDistance = hit.transform.position - mover.transform.position;

                    if (shedDistance.magnitude < shedOpenDistance)
                    {
                        onShedClick.Invoke(hit.collider.GetComponent<Shed>());
                    }
                }
            }
        }
    }

    public void AddShedClickListener(UnityAction<Shed> listener)
    {
        onShedClick.AddListener(listener);
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public Mover Mover { get => mover; }
    public Carrier Carrier { get => carrier; }
}
