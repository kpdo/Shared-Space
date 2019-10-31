using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    WebVRManager vrManager;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        vrManager = WebVRManager.instance;
  
        if(vrManager.vrState == WebVRState.NORMAL)
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
