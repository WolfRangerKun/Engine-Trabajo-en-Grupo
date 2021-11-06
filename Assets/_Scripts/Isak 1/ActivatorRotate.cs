using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatorRotate : MonoBehaviour
{
    public UnityEvent actionsIn,actionsOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionsIn?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actionsOut?.Invoke();
        }
    }
}
