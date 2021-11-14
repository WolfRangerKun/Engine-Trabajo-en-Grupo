using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    public float impulse;
    bool canJump = true;
    public AudioSource jumpSfx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canJump)
        {
            jumpSfx.Play();
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<Rigidbody>().isKinematic = false;

            other.GetComponent<Rigidbody>().AddForce(transform.forward * impulse /3*2 * Time.deltaTime, ForceMode.Impulse);
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * impulse * 5f * Time.deltaTime, ForceMode.Impulse);
            StartCoroutine("Active");
            canJump = false;
        }
    }



    IEnumerator Active()
    {
        yield return new WaitForSeconds(2);
        canJump = true;
        yield break;
    }


}
