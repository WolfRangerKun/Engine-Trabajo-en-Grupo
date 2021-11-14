using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool isGrabbed;
    private bool canPressQ;

    public HingeJoint hJoint;
    public GameObject player;
    public GameObject gameobjectRb;

    public AudioSource auSource;
    public AudioClip agarar, soltar;
    private void Start()
    {
        auSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
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
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
                Debug.Log("agarrado");
               
            }
            else
            {
                other.GetComponent<PlayerMovement>().canMove = true;
                other.GetComponent<Rigidbody>().AddForce(Vector3.zero, ForceMode.Impulse);
                hJoint.connectedBody = gameobjectRb.GetComponent<Rigidbody>();
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                Debug.Log("soltado");
                
            }
            //if (canPressQ && Input.GetKeyDown(KeyCode.Q))
            //{
            //    ApretarQ(other);
            //}
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isGrabbed)
        {
            canPressQ = false;
        }
    }

    private void Update()
    {

            if (canPressQ && Input.GetKeyDown(KeyCode.Mouse0) )
            {
                ApretarQ();
            }
        if (canPressQ && isGrabbed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Impulse);
            }

            if (Input.GetKey(KeyCode.D))
            {
                player.GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.Impulse);
            }
        }
    }
    public void ApretarQ()
    {
        isGrabbed = !isGrabbed;
        if (isGrabbed)
        {
            auSource.clip = agarar;
            auSource.Play();
        }
        else
        {
            auSource.clip = soltar;
            auSource.Play();
        }
        
    }


}
