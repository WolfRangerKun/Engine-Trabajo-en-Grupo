using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFinal : MonoBehaviour
{
    public GameObject bgm,rawImage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //bgm.SetActive(false);
            PlayerMovement.intance.canMove = false;
            rawImage.SetActive(true);
        }
    }
}
