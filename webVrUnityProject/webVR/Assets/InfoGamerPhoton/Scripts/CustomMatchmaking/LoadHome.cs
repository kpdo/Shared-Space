using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class LoadHome : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneStart);
    }

    void LoadSceneStart()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene("CustomMatchmakingMenuDemo");
    }
}