using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ObjectUploader : MonoBehaviourPun
{
    public static ObjectUploader singleton;
    public bool noPhoton;
    public bool spawnAtStart;
    public List<string> startModelUrls;
    
    private void Awake()
    {
        if (singleton != null && singleton != this)
            Destroy(this);
        singleton = this;
    }
    private void Start()
    {
        if(spawnAtStart)
        foreach(string s in startModelUrls) { UploadModel(s); }
    }

    //Called by someone who wants to set the score
    public void UploadModel(string url)
    {
        if(!noPhoton)
            this.photonView.RPC("ImportModel", RpcTarget.All, url);
        else
        {
            ImportModel(url);
        }
        
    }

    [PunRPC]
    public void ImportModel(string url)
    {
        ObjectImport.instance.ImportModelURL(url);
        //Do something with the score
    }
}
