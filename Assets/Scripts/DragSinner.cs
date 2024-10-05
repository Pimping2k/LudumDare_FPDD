using UnityEngine;

public class DragSinner : MonoBehaviour
{
    private Vector3 offset;
    private float mZCoord;
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        gameObject.transform.position = GetMouseWorldPosition() + offset;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
