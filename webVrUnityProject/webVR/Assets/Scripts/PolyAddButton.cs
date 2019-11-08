using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using PolyToolkit;

public class PolyAddButton : Button
{
    public Text text;
    public RawImage rawImage;
    //public PolyAsset myAsset;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponentInChildren<Text>();
        rawImage = GetComponent<RawImage>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //ObjectImporter.UploadObject(myAsset);
    }

}
