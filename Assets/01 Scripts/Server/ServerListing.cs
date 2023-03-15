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

        // Main Scene �ε�
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

        // ���� ������Ʈ ����
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            go.SetActive(false);
        }
        // Additive Scene unload �̰� ����
        SceneManager.UnloadSceneAsync("Main");
    }
}