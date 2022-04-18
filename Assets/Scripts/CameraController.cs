using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 lastPosition = Vector3.zero;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragging = true;
            lastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            dragging = false;
            lastPosition = Vector3.zero;
        }

        if (dragging)
        {
            Vector3 delta = Input.mousePosition - lastPosition;

            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + delta.x, 0);

            lastPosition = Input.mousePosition;
        }
    }
}
