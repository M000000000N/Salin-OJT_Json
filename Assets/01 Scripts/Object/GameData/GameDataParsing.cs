using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
public class GameDataParsing : MonoBehaviour
{
    [SerializeField] GameData data;
    [SerializeField] TextMeshProUGUI stateText;

    void Start()
    {
        SaveJson();
    }

    public void SaveJson() // 스크립터블 오브젝트를 json으로 저장
    {
        string json = JsonUtility.ToJson(data, true);
        Debug.Log("제이슨\n" + json);

        string fileName = "GameData1";
        string path = Application.dataPath + '/' + fileName + ".json";

        File.WriteAllText(path, json);
        stateText.text = $"스크립터블\nServer : {data.server}\nHp : {data.hp}\nScore : {data.score}\nSound : {data.sound}\nVibe : {data.vibe}";
    }
}
