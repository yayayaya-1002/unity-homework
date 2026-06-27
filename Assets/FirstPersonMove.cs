using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    private CharacterController controller;
    private float xRotate = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        // 锁定鼠标在游戏窗口内
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 鼠标左右、上下旋转视角
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotate, 0, 0);

        // WASD移动
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDir = transform.right * horizontal + transform.forward * vertical;
        controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
    }
}