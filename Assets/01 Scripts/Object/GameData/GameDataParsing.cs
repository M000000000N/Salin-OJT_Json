using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDataParsing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stateText;

    string path;
    string fileName = "GameData2";
    void Start()
    {
        path = Application.dataPath + "/";
        SaveData();
        LoadData();
    }

    public void SaveData()
    {
        // 1. 오브젝트를 JSON형태의 string 형식으로 바꿈
        string json = JsonUtility.ToJson(GameData.Instance, true);

        // 2. 설정한 주소에 json저장
        File.WriteAllText(path + fileName, json);

        // 3. 상태UI 설정
        stateText.text = 
            $"Server : {GameData.Instance.server}\n" +
            $"Hp : {GameData.Instance.hp}\n" +
            $"Score : {GameData.Instance.score}";
    }

    public void LoadData()
    {
        // 1. 설정한 주소에서 json 받아옴
        string json = File.ReadAllText(path + fileName);
        JsonUtility.FromJsonOverwrite(json, GameData.Instance);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
