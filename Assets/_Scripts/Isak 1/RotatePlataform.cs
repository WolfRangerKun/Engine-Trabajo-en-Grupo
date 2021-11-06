using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlataform : MonoBehaviour
{
    public bool canMove;
    Quaternion cd;
    private void FixedUpdate()
    {
        if (canMove && Input.GetMouseButton(0))
        {
            transform.rotation = cd;
            Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
            Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            Vector3 direction = mouseOnScreen - positionOnScreen;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            cd = Quaternion.Euler(new Vector3(0, -angle, 0));
             transform.rotation = cd;
        }

    }

    //Vector3 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
    //Vector3 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

    //Vector3 direction = mouseOnScreen - positionOnScreen;

    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
    //transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

    public void ChangeStatus()
    {
        canMove = !canMove;
    }
}