using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void Update()
    {
        if (isDragging)
        {
            MoveObjectWithMouse();
        }
    }

    private void OnMouseDown()
    {
        StartDragging();
    }

    private void OnMouseUp()
    {
        StopDragging();
    }

    private void StartDragging()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void StopDragging()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void MoveObjectWithMouse()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
}
