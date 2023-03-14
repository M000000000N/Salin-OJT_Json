using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
public class Network : MonoBehaviour
{
    private ServerListData data;
    public ServerListData Data { get { return data; }  }

    [System.Serializable]
    public struct ServerListData
    {
        public List<ServerDto> rows;
    }

    [System.Serializable]
    public struct ServerDto
    {
        public string serverid;
        public string serverName;
    }

    void Awake()
    {
        StartCoroutine(WebRequestGet());
    }

    IEnumerator WebRequestGet()
    {
        string url = "https://api.neople.co.kr/df/servers?apikey=vDk9MxNJ7nup36IA3l4cfOQlxAhgx19H";
        
        UnityWebRequest www = UnityWebRequest.Get(url); // ������ ��û

        yield return www.SendWebRequest(); // ������ ���ƿ� �� ���� ��ٸ�

        if(www.error == null)
        {
            string json = www.downloadHandler.text; // ������ �ؽ�Ʈ�� ������
            Debug.Log(www.downloadHandler.text);

            data = JsonUtility.FromJson<ServerListData>(json); // json ���Ͽ��� ���� ������ ����

            // string jsonString = JsonUtility.ToJson(data, true); // json���� �̻ڰ� ��ȯ

            for (int i = 0; i < data.rows.Count; i++)
            {
                Debug.Log(data.rows[i].serverName);
            }
        }
        else
        {
            Debug.Log("������ �ҷ����� ���߽��ϴ�.");
        }
    }
}
