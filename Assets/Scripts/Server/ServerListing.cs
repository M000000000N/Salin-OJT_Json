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
        // 1. 현재 접속 서버이름 전달
        // 2. addictScene 활용
        // 3. 현재 접속 서버 이름 저장

        SceneManager.LoadScene("Main");

    }
}
