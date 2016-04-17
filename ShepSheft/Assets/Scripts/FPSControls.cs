using UnityEngine;
using System.Collections;

public class FPSControls : MonoBehaviour
{
    public float groundSpeed;
    public float airSpeed;
    public float jumpForce;

    float speed;
    bool isGrounded;
    bool canJump;


    void Start()
    {
        //Lock & hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //Freeze rigidbody roations
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update ()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.8f);
        if (isGrounded)
            canJump = true;
        if (isGrounded)
                speed = groundSpeed;
            else
                speed = airSpeed;
        //Movement
        Vector3 movement = Vector3.zero;
        movement = (Input.GetAxis("Vertical") * transform.forward);
        movement += (Input.GetAxis("Horizontal") * transform.right);
        movement *= speed * Time.deltaTime;
        transform.position += movement;

        //Character Rotation (X axis)
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

        //Jump
        if (Input.GetButtonDown("Jump"))
            Jump();
    }

    void Jump ()
    {
        if (canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            canJump = false;
        }
    }
}
