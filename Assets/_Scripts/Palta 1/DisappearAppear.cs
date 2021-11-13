using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAppear : MonoBehaviour
{
    public PlayerMovement playerMov;
    public bool disappear;
    public List<GameObject> gameObjectsListDisappear;
    public List<GameObject> gameObjectsListAppear;

    private void Start()
    {
        for (int i = 0; i < gameObjectsListDisappear.Count; ++i)
        {
            gameObjectsListAppear[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && playerMov.canMove)
        {
            Disappear();
            if(disappear)
            {
                Desaparecio();
            }
            else
            {
                Aparecio();
            }
        }
    }
    public void Disappear()
    {
        disappear = !disappear;
    }

     public void Desaparecio()
    {
        for(int i = 0; i < gameObjectsListDisappear.Count; ++i)
        {
            gameObjectsListDisappear[i].SetActive(false);
        }

        for (int i = 0; i < gameObjectsListAppear.Count; ++i)
        {
            gameObjectsListAppear[i].SetActive(true);
        }
    }

    public void Aparecio()
    {
        for (int i = 0; i < gameObjectsListDisappear.Count; ++i)
        {
            gameObjectsListDisappear[i].SetActive(true);
        }

        for (int i = 0; i < gameObjectsListAppear.Count; ++i)
        {
            gameObjectsListAppear[i].SetActive(false);
        }
    }
}
