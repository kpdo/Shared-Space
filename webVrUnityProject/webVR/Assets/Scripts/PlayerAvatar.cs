using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAvatar : NetworkBehaviour
{
    public TransformFollow leftHand;
    public TransformFollow rightHand;
    public TransformFollow head;
    private void Start()
    {
        print("is Local Player Authority: " + localPlayerAuthority);
        print("is Local Player: " + isLocalPlayer);
        if (!isLocalPlayer)
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
