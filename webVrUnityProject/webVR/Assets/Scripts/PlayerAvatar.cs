using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAvatar : MonoBehaviour
{
    public TransformFollow leftHand;
    public TransformFollow rightHand;
    public TransformFollow head;

    PhotonView PV;
    private void Start()
    {
        PV = GetComponent<PhotonView>();

        if (!PV.IsMine || AvatarHandler.instance == null)
        {
            return;
        }

        leftHand.target = AvatarHandler.instance.leftHand;
        rightHand.target = AvatarHandler.instance.rightHand;
        head.target = AvatarHandler.instance.head;

        head.gameObject.layer = 8;
        foreach (Transform t in head.GetComponentsInChildren<Transform>())
        {
            t.gameObject.layer = 8;
        }

       
    }
    // Start is called before the first frame update

}
