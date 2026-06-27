using UnityEngine;

public class DragApple : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCam;
    private Rigidbody rb;

    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        offset = transform.position - mainCam.ScreenToWorldPoint(Input.mousePosition);
        rb.isKinematic = true;
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        // 固定Y轴高度，不让苹果上下飘
        mousePos.y = transform.position.y;
        transform.position = mousePos + offset;
    }

    void OnMouseUp()
    {
        rb.isKinematic = false;
    }
}