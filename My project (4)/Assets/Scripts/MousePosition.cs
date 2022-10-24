using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 mouseToWorld(Vector3 oldMousePos)
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldPos;
        RaycastHit hit;

        bool hitSomething;

        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, 0));

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        hitSomething = Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (hitSomething == true)
        {
            worldPos = hit.point;
            return worldPos;
        }

        else
        {
            return oldMousePos;
        }

    }
}
