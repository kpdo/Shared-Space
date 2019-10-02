using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TransformFollow : MonoBehaviour
{
    public Transform target;
    public bool follow;

    void Update()
    {
        if (follow && target!=null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }
}

