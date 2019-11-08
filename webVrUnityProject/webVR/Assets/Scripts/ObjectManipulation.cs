using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectManipulation : MonoBehaviour
{
    public float rotateSpeed =180;
    public GameObject selectedObject;
    public GameObject previousObject;
    public GameObject controlPanel;
    public Material highlightedMaterial;
    public Material wireframeMaterial;
    public Material defaultMaterial;
    public Material prevMaterial;
    public Text modelNameDisplay;
    public Toggle tgl_wireframe;
    // Update is called once per frame
    private void Start()
    {
        previousObject = gameObject;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Interactable"))
                {

                    selectedObject = hit.collider.gameObject;
                    controlPanel.SetActive(true);

                    if ( selectedObject != previousObject)
                    {
                        tgl_wireframe.isOn = selectedObject.GetComponentInChildren<Renderer>().material == wireframeMaterial;
                        if (prevMaterial)
                        {
                    
                            previousObject.GetComponentInChildren<Renderer>().material = prevMaterial;
                        }                           
                        
                        prevMaterial = selectedObject.GetComponentInChildren<Renderer>().material;
                        highlightedMaterial.mainTexture = prevMaterial.mainTexture;
                        selectedObject.GetComponentInChildren<Renderer>().material = highlightedMaterial;
                        modelNameDisplay.text = selectedObject.name;
                        previousObject = selectedObject;
                        
                    }
                    
                        
                }
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
        GetComponentInChildren<FreeFlightController>().translationEnabled = !Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.UpArrow))
        {
            if (previousObject)
            {
                previousObject.transform.Rotate(0, 0, -180 * Time.deltaTime);
            }
            
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.DownArrow))
        {
            if(previousObject)
            previousObject.transform.Rotate(0, 0, 180 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
        {
            if (previousObject)
            {
                previousObject.transform.Rotate(0, -180 * Time.deltaTime, 0);
            }

        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow))
        {
            if (previousObject)
                previousObject.transform.Rotate(0, 180 * Time.deltaTime, 0);
        }
    }
    public void DeleteObject()
    {
        if(previousObject)
            previousObject.SetActive(false);
    }
    
    public void Rotate(string a)
    {
        print("Rotating Axis:" + a);
        Vector3 axis = Vector3.zero;
        if (a == "x") axis = Vector3.right;
        else if (a == "y") axis = Vector3.up;
        else if (a == "z") axis = Vector3.forward;
        
        float s = rotateSpeed * Time.deltaTime;
        previousObject.transform.Rotate(s*axis);
    }
    public void SetWireframe(bool value)
    {
        previousObject.GetComponentInChildren<Renderer>().material = value? wireframeMaterial: highlightedMaterial;
    }

}