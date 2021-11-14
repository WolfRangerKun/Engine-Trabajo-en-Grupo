using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class DollyManager : MonoBehaviour
{
    public List<GameObject> dollys;
    public List<CinemachineVirtualCamera> cvs;


    //private void Start()
    ////{
    ////    PlayerMovement.intance.canMove = false;
    ////    StartCoroutine("Dolly");
    ////}

    IEnumerator Dolly()
    {
        
        yield return new WaitWhile(() => dollys[0].GetComponent<CinemachineDollyCart>().m_Position< 29.80f);
        dollys[1].SetActive(true);

        dollys[0].SetActive(false);
        yield return new WaitWhile(() => dollys[1].GetComponent<CinemachineDollyCart>().m_Position < 39.70f);
        dollys[2].SetActive(true);

        dollys[1].SetActive(false);

        yield return new WaitWhile(() => dollys[0].GetComponent<CinemachineDollyCart>().m_Position < 58f);

        cvs[2].m_LookAt = GameObject.Find("300").transform;
        PlayerMovement.intance.canMove = true;

    }
}
