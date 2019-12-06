using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class TransformSync : MonoBehaviour
{
    [PunRPC]
    public void SyncTransform(string obj)
    {
        GameObject model = GameObject.Find(obj);
        model.transform.position = transform.position;
        model.transform.rotation = transform.rotation;
        
    }
}
