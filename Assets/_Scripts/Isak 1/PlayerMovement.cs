using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement intance;
    public float speed = 20;
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        intance = this;
    }

    Vector3 playerInput;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public bool canMove = true, changeCamera;
    public bool gotPov;
    public bool isGraving;
   

    private void FixedUpdate()
    {
        float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        playerInput = new Vector3(z, 0, x);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        if (playerInput.magnitude >= .1f && canMove)
        {
            float targetAngle = Mathf.Atan2(playerInput.x, playerInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0);

            rb.MovePosition(transform.position + moveDir * speed * Time.deltaTime);
        }

    }
}
