using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPart : MonoBehaviour
{
    public Transform scenePosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = scenePosition.position;
        }
    }
}
