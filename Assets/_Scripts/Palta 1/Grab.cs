using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    private bool isGrabbed;
    private bool canPressQ;
    public HingeJoint hJoint;
    public GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            #region prueba_1
            //Debug.Log("esta");
            //if (Input.GetKeyDown(KeyCode.Q))
            //{
            //    Debug.Log("Entro");
            //    ApretarQ(other);

            //}
            //if (Input.GetKeyUp(KeyCode.Q))
            //{
            //    Debug.Log("Salio");
            //    ApretarQ(other);

            //}
            #endregion
            canPressQ = true;

            if (isGrabbed)
            {
                other.GetComponent<PlayerMovement>().canMove = false;
                hJoint.connectedBody = other.GetComponent<Rigidbody>();
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                Debug.Log("agarrado");
            }
            else
            {
                other.GetComponent<PlayerMovement>().canMove = true;
                hJoint.connectedBody = null;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("soltado");
            }
            //if (canPressQ && Input.GetKeyDown(KeyCode.Q))
            //{
            //    ApretarQ(other);
            //}
        }
    }

    private void Update()
    {

            if (canPressQ && Input.GetKeyDown(KeyCode.Q))
            {
                ApretarQ();
            }
        if (canPressQ && isGrabbed)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.S))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.Impulse);
            }
        }
    }
    public void ApretarQ()
    {
        isGrabbed = !isGrabbed;
        
    }
}
