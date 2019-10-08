using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotateSpeed;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.Self);
    }
}
