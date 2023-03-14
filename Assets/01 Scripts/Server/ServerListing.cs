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
        // �����͸� ���� GameObject ����
        GameObject dataObject = new GameObject("DataObject");
        dataObject.AddComponent<MyDataComponent>();
        dataObject.GetComponent<MyDataComponent>().myData = this.serverName.text;


        // Main Scene �ε�
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

        // Main Scene���� ������ ��������
        Scene mainScene = SceneManager.GetSceneByName("Main");
        GameObject[] rootObjects = mainScene.GetRootGameObjects();
        foreach (GameObject rootObject in rootObjects)
        {
            MyDataComponent dataComponent = rootObject.GetComponent<MyDataComponent>();
            if (dataComponent != null)
            {
                Debug.Log(dataComponent.myData);
            }
        }

        // ���� ������Ʈ ����
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            go.SetActive(false);
        }
        // Additive Scene unload
        SceneManager.UnloadSceneAsync("Main");
    }
}