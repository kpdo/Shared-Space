using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneCustomMatchmakingMenuDemo : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneStart);
    }

    void LoadSceneStart()
    {
        SceneManager.LoadScene("CustomMatchmakingMenuDemo");
    }
}