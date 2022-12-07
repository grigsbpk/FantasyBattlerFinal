using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class Main : NetworkBehaviour
{

    public Button btnHost;
    public Button btnClient;
    public TMPro.TMP_Text txtWelcome;
    public TMPro.TMP_Text txtChoose;
    public TMPro.TMP_Text txtStatus;

    // Start is called before the first frame update
    public void Start()
    {
        btnHost.onClick.AddListener(OnHostClicked);
        btnClient.onClick.AddListener(OnClientClicked);
        Application.targetFrameRate = 30;
    }

    private void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.SceneManager.LoadScene(
            "LobbyScene",
            UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    private void OnHostClicked()
    {
        btnClient.gameObject.SetActive(false);
        btnHost.gameObject.SetActive(false);
        StartHost();
    }

    private void OnClientClicked()
    {
        btnClient.gameObject.SetActive(false);
        btnHost.gameObject.SetActive(false);
        NetworkManager.Singleton.StartClient();
        txtWelcome.gameObject.SetActive(false);
        txtChoose.gameObject.SetActive(false);
        txtStatus.gameObject.SetActive(true);
    }
}
