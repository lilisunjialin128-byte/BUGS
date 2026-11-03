using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    public Transform cam;
    private float xRot;

    public float speed = 10f;
    public float rotateSpeed = 1f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float checkRadius = 0.2f; 
    public bool isGround;
    public LayerMask layerMask;
    public float jumpHeight= 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoveLikeWow();
    }

    private void MoveLikeWow()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, layerMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0;
        }

        if (isGround && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight* -2 * gravity);
        }

        
        var vertical = Input.GetAxis("Vertical");
        var move = (transform.forward * vertical + transform.right * Input.GetAxis("Horizontal")) * speed * Time.deltaTime;

        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed);

        xRot = Mathf.Clamp(xRot - Input.GetAxis("Mouse Y") * rotateSpeed, -80f, 80f);
        cam.localRotation = Quaternion.Euler(xRot, 0, 0);
    }

    private void OnControllerColliderHit (ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Finish"))
        {
            hit.rigidbody.AddForce(transform.forward * speed);
        }
    }
}
