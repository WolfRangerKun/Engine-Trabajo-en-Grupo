using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlataform : MonoBehaviour
{
    public bool canMove;
    public Transform toRotate;
    Quaternion saveRotation;
    public AudioSource dragSfx;

    private void OnMouseDrag()
    {
        if (canMove )
        {
            Rotation();
        }
    }

    private void OnMouseDown()
    {
        dragSfx.Play();
    }
    public void ChangeStatus()
    {
        canMove = !canMove;
    }

    void Rotation()
    {
        Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(toRotate.position);
        Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        Vector3 direction = mouseOnScreen - positionOnScreen;

        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f) + saveRotation.y;


        toRotate.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

    }
}
