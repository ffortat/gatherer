using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover = null;

    private void Awake()
    {
        mover = GetComponentInChildren<Mover>();
    }

    private void Update()
    {
        RaycastHit hit;
        LayerMask tileMask = LayerMask.GetMask("Tile");

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, tileMask))
        {
            if (Input.GetMouseButton(0))
            {
                mover.MoveTo(hit.point);
            }
        }
    }

    public Mover Mover { get => mover; }
}
