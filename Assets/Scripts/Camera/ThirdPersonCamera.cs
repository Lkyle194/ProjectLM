using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Référence au joueur
    public Transform cameraTransform;
    public Vector2 sensitivity = new Vector2(2f, 2f);
    public Vector2 rotationClamp = new Vector2(-30f, 60f);

    float pitch = 0f;
    float yaw = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity.x;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity.y;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, rotationClamp.x, rotationClamp.y);

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}