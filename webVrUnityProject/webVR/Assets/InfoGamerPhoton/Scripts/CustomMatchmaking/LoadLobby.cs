using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LoadLobby: MonoBehaviour
{
    public Button yourButton;
    public GameObject networking;
    public GameObject ui;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneStart);
    }

    void LoadSceneStart()
    {
        networking.SetActive(true);
        ui.SetActive(false);
        PhotonNetwork.LeaveRoom();
    }
}