using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayoInador : MonoBehaviour
{
    public float distanceRay, scaleValue, massValue;
    public Transform originRay;
    public enum CambioDeEfectos
    {
        MASPESO,
        MENOSPESO,
        AGRANDAR,
        ACHICAR,
        NONEEFFECT
    }
    public CambioDeEfectos cambioDeEfectos;
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RayEffect();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(cambioDeEfectos >= 0)
            {
                cambioDeEfectos++;
            }
            if(cambioDeEfectos == CambioDeEfectos.NONEEFFECT)
            {
                cambioDeEfectos = CambioDeEfectos.MASPESO;
            }

        }
    }
    public void RayEffect()
    {
        RaycastHit hit;
        Debug.DrawRay(originRay.position, transform.forward, Color.green, distanceRay);
        Physics.Raycast(originRay.position, transform.forward, out hit, distanceRay);
        if (hit.collider)
        {
            ChangePropierties(hit.collider.gameObject);
        }
    }
    public void ChangePropierties(GameObject affect)
    {
        switch (cambioDeEfectos)
        {
            case CambioDeEfectos.MASPESO:
                affect.GetComponent<Rigidbody>().mass += massValue * Time.deltaTime;
                affect.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case CambioDeEfectos.MENOSPESO:
                affect.GetComponent<Rigidbody>().mass -= massValue * Time.deltaTime;
                affect.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case CambioDeEfectos.AGRANDAR:
                affect.transform.localScale += new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, scaleValue * Time.deltaTime);
                affect.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
            case CambioDeEfectos.ACHICAR:
                affect.transform.localScale -= new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, scaleValue * Time.deltaTime);
                affect.GetComponent<MeshRenderer>().material.color = Color.white;
                break;
        }
    }
}
