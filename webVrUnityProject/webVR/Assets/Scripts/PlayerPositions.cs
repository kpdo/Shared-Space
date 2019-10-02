using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPositions : MonoBehaviour
{
    public Text display;
    void Update()
    {
        ShowPositions();
    }
    void ShowPositions()
    {
        int i = 0;
        display.text = "";
        foreach (PlayerAvatar p in GameObject.FindObjectsOfType<PlayerAvatar>())
        {
            i++;
            display.text += "\n Player: "+i+ "(" + p.head.transform.position+")";
        }
    }
}
