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
        // 1. ������Ʈ�� JSON������ string �������� �ٲ�
        string json = JsonUtility.ToJson(GameData.Instance, true);

        // 2. ������ �ּҿ� json����
        File.WriteAllText(path + fileName, json);

        // 3. ����UI ����
        stateText.text = 
            $"Server : {GameData.Instance.Server}\n" +
            $"Hp : {GameData.Instance.Hp}\n" +
            $"Score : {GameData.Instance.Score}";
    }

    public void LoadData()
    {
        // 1. ������ �ּҿ��� json �޾ƿ�
        string json = File.ReadAllText(path + fileName);
        JsonUtility.FromJsonOverwrite(json, GameData.Instance);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
