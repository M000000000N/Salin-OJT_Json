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
        // 1. 데이터 오브젝트 생성
        dataObject = new GameObject("DataObject");
        dataObject.AddComponent<GameData>();

        // 2. JSON파일로 부터 게임데이터저장
        string json = File.ReadAllText(path + fileName);
        JsonUtility.FromJsonOverwrite(json, GameData.Instance);

        // 3. 서버데이터 변경
        GameData.Instance.Server = serverName.text;
        GameData.Instance.Hp = 5;
        GameData.Instance.Score = 0;

        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        // 1. 나중에 언로드 될 현재 씬 저장
        Scene currentScene = SceneManager.GetActiveScene();

        // [개선필요] 카메라 해제
        Camera.main.enabled = false;

        // 2. 현재 씬과 동시에 백그라운드에서 메인씬 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive); 

        while (!asyncLoad.isDone) // 로드 된 후
        {
            yield return null;
        }

        // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));

        // 3. 데이터 오브젝트를 메인에 옮겨줌
        SceneManager.MoveGameObjectToScene(dataObject, SceneManager.GetSceneByName("Main"));

        // 4. 이전 씬 해제
        SceneManager.UnloadSceneAsync(currentScene); 
    }
}