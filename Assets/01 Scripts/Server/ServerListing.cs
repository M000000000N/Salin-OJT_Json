using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ServerListing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI serverName;
    private Button enterServer;
    [SerializeField] GameData data;

    private void Start()
    {
        enterServer = GetComponent<Button>();
        enterServer.onClick.AddListener(OnClickEnterServer);
    }
    public void SetServerName(Network.ServerDto ServerDto)
    {
        this.serverName.text = ServerDto.serverName;
    }
    public void OnClickEnterServer()
    {
        data.server = serverName.text;

        // Main Scene ·Îµå
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

        // ÀÌÀü ÄÄÆ÷³ÍÆ® ²ô±â
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            go.SetActive(false);
        }
        // Additive Scene unload ÀÌ°Ô ¹¹Áö
        SceneManager.UnloadSceneAsync("Main");
    }
}