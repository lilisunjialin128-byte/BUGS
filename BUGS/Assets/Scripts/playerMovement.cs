using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    public float speed = 10f;
    public float rotateSpeed = 1f;
    public float gravity = -9.8f;
    public Transform groundCheck;
    public float checkRadius = 0.2f; 
    private bool isGround;
    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
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

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move = transform.forward * speed * vertical * Time.deltaTime;
        controller.Move(move);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        transform.Rotate(Vector3.up,horizontal * rotateSpeed);
    }
}
