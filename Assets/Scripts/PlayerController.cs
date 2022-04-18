using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string tileTag = "Tile";
    private const string shedTag = "Shed";

    private Mover mover = null;
    private Carrier carrier = null;

    private void Awake()
    {
        mover = GetComponentInChildren<Mover>();
        carrier = GetComponentInChildren<Carrier>();
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
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    public Mover Mover { get => mover; }
}
