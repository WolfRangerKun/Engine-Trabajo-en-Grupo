using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float impulse;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Rigidbody>().AddForce(transform.forward * impulse /3*2 * Time.deltaTime, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * impulse * 5f * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
