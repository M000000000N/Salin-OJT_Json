using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ServerListing : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI serverName;
    private Button enterServer;


    [SerializeField] GameObject dataObject;
    string path;
    string fileName = "GameData2";

    private void Start()
    {
        enterServer = GetComponent<Button>();
        enterServer.onClick.AddListener(OnClickEnterServer);

        path = Application.dataPath + "/";

    }

    public void SetServerName(Network.ServerDto ServerDto)
    {
        this.serverName.text = ServerDto.serverName;
    }

    public void OnClickEnterServer()
    {
        // 1. ������ ������Ʈ ����
        dataObject = new GameObject("DataObject");
        dataObject.AddComponent<GameData>();

        // 2. JSON���Ϸ� ���� ���ӵ���������
        string json = File.ReadAllText(path + fileName);
        JsonUtility.FromJsonOverwrite(json, GameData.Instance);

        // 3. ���������� ����
        GameData.Instance.Server = serverName.text;
        GameData.Instance.Hp = 5;
        GameData.Instance.Score = 0;

        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // 1. ���߿� ��ε� �� ���� �� ����
        Scene currentScene = SceneManager.GetActiveScene();

        // [�����ʿ�] ī�޶� ����
        Camera.main.enabled = false;

        // 2. ���� ���� ���ÿ� ��׶��忡�� ���ξ� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive); 

        while (!asyncLoad.isDone) // �ε� �� ��
        {
            yield return null;
        }

        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));

        // 3. ������ ������Ʈ�� ���ο� �Ű���
        SceneManager.MoveGameObjectToScene(dataObject, SceneManager.GetSceneByName("Main"));

        // 4. ���� �� ����
        SceneManager.UnloadSceneAsync(currentScene); 
    }
}