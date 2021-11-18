using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RayoInador : MonoBehaviour
{
    public float distanceRay, scaleValue, massValue;
    public Transform originRay;
    public LayerMask boxs;
    public TMP_Text status;
    public List<AudioSource> sonidosAudios;
    bool sfx = true;

    public void Start()
    {
        sfx = true;
    }
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
        status.text = "Efecto: " + cambioDeEfectos.ToString();
        if (Input.GetKey(KeyCode.Mouse1))
        {
            RayEffect();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
            sfx = true;
        if (Input.GetKeyDown(KeyCode.Q))
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
        Physics.Raycast(originRay.position, transform.forward, out hit, distanceRay, boxs);
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
                affect.GetComponent<Rigidbody>().mass = 100;
                affect.GetComponent<MeshRenderer>().material.color = Color.red;
                affect.GetComponent<Rigidbody>().useGravity = false;
                affect.GetComponent<Rigidbody>().isKinematic = true;
                if (sfx)
                {
                    sonidosAudios[0].Play();
                    sfx = false;
                }
                break;
            case CambioDeEfectos.MENOSPESO:
                affect.GetComponent<Rigidbody>().mass = 1;
                affect.GetComponent<MeshRenderer>().material.color = Color.blue;
                affect.GetComponent<Rigidbody>().useGravity = true;
                affect.GetComponent<Rigidbody>().isKinematic = false;
                if (sfx)
                {
                    sonidosAudios[1].Play();
                    sfx = false;
                }
                break;
            case CambioDeEfectos.AGRANDAR:
                affect.transform.localScale += new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, scaleValue * Time.deltaTime);
                affect.GetComponent<MeshRenderer>().material.color = Color.magenta;
                if (sfx)
                {
                    sonidosAudios[2].Play();
                    sfx = false;
                }
                break;
            case CambioDeEfectos.ACHICAR:
                affect.transform.localScale -= new Vector3(scaleValue * Time.deltaTime, scaleValue * Time.deltaTime, scaleValue * Time.deltaTime);
                affect.GetComponent<MeshRenderer>().material.color = Color.yellow;
                if (sfx)
                {
                    sonidosAudios[3].Play();
                    sfx = false;
                }
                break;
        }
    }
}
