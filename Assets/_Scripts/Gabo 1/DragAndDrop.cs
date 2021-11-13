using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public GameObject handPoint;

    GameObject pickedObject = null;
    void Start()
    {

    }

    void Update()
    {
        if (pickedObject != null)
        {
            pickedObject.GetComponent<Rigidbody>().useGravity = true;
            pickedObject.gameObject.transform.SetParent(null);
            pickedObject = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            if(Input.GetKey(KeyCode.E) && pickedObject == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.transform.position = handPoint.transform.position;
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
}
