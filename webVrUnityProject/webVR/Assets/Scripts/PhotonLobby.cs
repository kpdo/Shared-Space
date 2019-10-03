using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public UnityEngine.Events.UnityEvent onConnectedToMaster;
    private void Awake()
    {
        lobby = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        print("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        onConnectedToMaster.Invoke();
    }
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom(null, 0);
    }
    void CreateRoom()
    {
        int randomRoomNum = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };
        PhotonNetwork.CreateRoom("Room" + randomRoomNum, roomOps);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        print("Room has been joined");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
