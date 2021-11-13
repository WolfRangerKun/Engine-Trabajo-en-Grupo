using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatorRotate : MonoBehaviour
{
    public List<GameObject> objetosCambioMaterial;
    public Material original;
    public Material nuevo;
    public GameObject flecha;

    public UnityEvent actionsIn,actionsOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flecha.SetActive(true);
            actionsIn?.Invoke();
            CambioMaterialGlow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flecha.SetActive(false);
            actionsOut?.Invoke();
            CambioMaterialOriginal();
        }
    }

    public void CambioMaterialGlow()
    {
        for (int i = 0; i < objetosCambioMaterial.Count; ++i)
        {
            objetosCambioMaterial[i].GetComponent<MeshRenderer>().material = nuevo;
        }
    }
    public void CambioMaterialOriginal()
    {
        for (int i = 0; i < objetosCambioMaterial.Count; ++i)
        {
            objetosCambioMaterial[i].GetComponent<MeshRenderer>().material = original;
        }
    }
}
