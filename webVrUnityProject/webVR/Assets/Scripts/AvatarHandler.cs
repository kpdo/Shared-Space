using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHandler : MonoBehaviour
{
    public static AvatarHandler instance;
    public Transform leftHand;
    public Transform rightHand;
    public Transform head;

    private void Awake()
    {
        if(instance==null)
        instance = this;
    }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
