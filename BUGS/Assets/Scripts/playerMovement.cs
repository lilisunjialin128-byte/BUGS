using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 10f;
    public float rotateSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLikeWow();
    }

    private void MoveLikeWow()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move = transform.forward * speed * vertical * Time.deltaTime;
        controller.Move(move);

        transform.Rotate(Vector3.up,horizontal * rotateSpeed);
    }
}
