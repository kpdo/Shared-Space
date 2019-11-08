using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CatalogObject : MonoBehaviour
{
    public GameObject model;
    Button btn;
    TextMeshProUGUI text;
    bool visible = true;
    // Start is called before the first frame update\

    private void Awake()
    {
        btn = GetComponentInChildren<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        btn.onClick.AddListener(ToggleModelActive);
        btn.image.color = btn.colors.pressedColor;

    }
    void Start()
    {
       
    }
    void ToggleModelActive()
    {
        visible = !visible;
        model.SetActive(visible);

        Color btnColor = visible ? btn.colors.pressedColor : btn.colors.normalColor;
        btn.image.color = btnColor;
    }
    public void SetObject(string modelName, GameObject model)
    {
        text.text = modelName;
        this.model = model;
    }


}
