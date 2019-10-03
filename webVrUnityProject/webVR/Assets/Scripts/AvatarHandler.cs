using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHandler : MonoBehaviour
{
    public static AvatarHandler instance;
    public Transform leftHand;
    public Transform rightHand;
    public Transform head;
    public Transform vrHead;
    WebVRManager vrManager;
    private void Awake()
    {
        if(instance==null)
        instance = this;

        vrManager = GetComponent<WebVRManager>();
        if(vrManager.vrState == WebVRState.ENABLED)
        {
            head = vrHead;
        }
    }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
}
