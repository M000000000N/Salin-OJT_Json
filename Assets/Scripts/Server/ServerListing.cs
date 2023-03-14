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
        // 데이터를 담은 GameObject 생성
        GameObject dataObject = new GameObject("DataObject");
        dataObject.AddComponent<MyDataComponent>();
        dataObject.GetComponent<MyDataComponent>().myData = this.serverName.text;


        // Main Scene 로드
        SceneManager.LoadSceneAsync("Main", LoadSceneMode.Additive);

        // Main Scene에서 데이터 가져오기
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

        // 이전 컴포넌트 끄기
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            go.SetActive(false);
        }
        // Additive Scene unload
        SceneManager.UnloadSceneAsync("Main");
    }
}