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

    public void SaveJson() // ��ũ���ͺ� ������Ʈ�� json���� ����
    {
        string json = JsonUtility.ToJson(data, true);
        Debug.Log("���̽�\n" + json);

        string fileName = "GameData1";
        string path = Application.dataPath + '/' + fileName + ".json";

        File.WriteAllText(path, json);
        stateText.text = $"��ũ���ͺ�\nServer : {data.server}\nHp : {data.hp}\nScore : {data.score}\nSound : {data.sound}\nVibe : {data.vibe}";
    }
}
