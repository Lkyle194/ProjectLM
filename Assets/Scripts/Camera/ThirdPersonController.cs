using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Base la direction du mouvement sur la rotation de la caméra
        Vector3 forward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
        Vector3 right = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

        moveDirection = (forward * v + right * h).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);

            // Le perso tourne vers sa direction de déplacement
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);

            LogMovement(moveDirection);
        }
    }

    void LogMovement(Vector3 dir)
    {
        string log = $"[{Time.time:F2}] Player moved: Dir={dir.normalized}, Pos={transform.position}";
        Debug.Log(log);
        System.IO.File.AppendAllText("movement_logs.txt", log + "\n");
    }
}