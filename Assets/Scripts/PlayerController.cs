using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private const string tileTag = "Tile";
    private const string shedTag = "Shed";

    private Mover mover = null;

    private UnityEvent<Shed> onShedClick = new UnityEvent<Shed>();

    private void Awake()
    {
        mover = GetComponentInChildren<Mover>();

    }

    private void Update()
    {
        RaycastHit hit;
        LayerMask tileMask = LayerMask.GetMask(tileTag, shedTag);

        if (Physics.Raycast(GetMouseRay(), out hit, tileMask))
        {
            if (Input.GetMouseButton(0))
            {
                switch (hit.collider.tag)
                {
                    case tileTag:
                        mover.MoveTo(hit.point);
                        break;
                    case shedTag:
                        onShedClick.Invoke(hit.collider.GetComponent<Shed>());
                        break;
                    default:
                        break;
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
}
