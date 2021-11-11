using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float impulse;
    bool canJump = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canJump)
        {

            other.GetComponent<Rigidbody>().AddForce(transform.forward * impulse /3*2 * Time.deltaTime, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * impulse * 5f * Time.deltaTime, ForceMode.Impulse);
            canJump = false;
            StartCoroutine("active");
        }
    }



    IEnumerator active()
    {
        yield return new WaitForSeconds(2);
        canJump = false;
        yield break;
    }
}
