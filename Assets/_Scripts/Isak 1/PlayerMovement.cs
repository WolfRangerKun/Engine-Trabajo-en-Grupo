using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement intance;
    public float speed = 20;
    Rigidbody rb;
    public float jumpForce;
    public LayerMask ground;
    public bool ejeZ = true;
    public float z;
    public float x;
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
        
        z = Input.GetAxis("Horizontal");
        if (ejeZ)
        {
            x = Input.GetAxis("Vertical");
        }
        else
        {
            x = 0;
        }
        


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
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0,1,0), -Vector3.up, out hit, 2, ground))
        {
            Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), -Vector3.up, Color.red, 7);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    public void ejeZFalse()
    {
        ejeZ = false;
    }
    
}
