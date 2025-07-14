using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;
    public Transform cameraTransform;

    private CharacterController controller;
    private Vector3 moveDirection;
    private float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = 0f;
        float v = 0f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) h += 1f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)) h -= 1f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) v += 1f;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) v -= 1f;

        // Base la direction du mouvement sur la rotation de la caméra
        Vector3 forward = new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z).normalized;
        Vector3 right = new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z).normalized;

        moveDirection = (forward * v + right * h).normalized;

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }

        if (!controller.isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        else if (verticalVelocity < 0f)
        {
            verticalVelocity = gravity * Time.deltaTime; // keep grounded
        }

        Vector3 velocity = moveDirection * moveSpeed;
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);

        if (moveDirection.magnitude > 0.1f)
        {
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