using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObject : MonoBehaviour
{
    public GameObject selectedObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Interactable"))
                    selectedObject = hit.collider.gameObject;
                    //hit.collider.gameObject.SetActive(false);
        }

        if (Input.GetMouseButton(0))
        {
            
            if (selectedObject != null)
            {
                Plane plane = new Plane(Vector3.up, transform.position);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float point = 0f;
                GetComponentInChildren<FreeFlightController>().rotationEnabled = false;
                if (plane.Raycast(ray, out point))
                    selectedObject.transform.position = ray.GetPoint(point);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponentInChildren<FreeFlightController>().rotationEnabled = true;
            selectedObject = null;
        }
    }
}
