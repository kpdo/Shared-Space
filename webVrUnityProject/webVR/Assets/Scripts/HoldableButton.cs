using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    EventTrigger trigger;


    public UnityEvent OnHold;
    bool _pressed;
    public  void OnPointerDown(PointerEventData eventData)
    {
        //base.OnPointerDown(eventData);
        print("Pressed");
        _pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // base.OnPointerUp(eventData);
        _pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_pressed) { OnHold.Invoke(); }
    }
}
