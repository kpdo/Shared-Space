using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectUploader : MonoBehaviourPun
{
    public static ObjectUploader singleton;

    
    private void Awake()
    {
        if (singleton != null && singleton != this)
            Destroy(this);
        singleton = this;
    }

    //Called by someone who wants to set the score
    public void UploadModel(string url)
    {
        this.photonView.RPC("ImportModel", RpcTarget.All, url);
    }

    [PunRPC]
    public void ImportModel(string url)
    {
        ObjectImport.instance.ImportModelURL(url);
        //Do something with the score
    }
}
