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
        
        UnityWebRequest www = UnityWebRequest.Get(url); // 정보를 요청

        yield return www.SendWebRequest(); // 응답이 돌아올 때 까지 기다림

        if(www.error == null)
        {
            string json = www.downloadHandler.text; // 응답을 텍스트로 보여줌

            data = JsonUtility.FromJson<ServerListData>(json); // json 파일에서 받은 데이터 저장

            // string jsonString = JsonUtility.ToJson(data, true); // json으로 이쁘게 변환
        }
        else
        {
            Debug.Log("서버를 불러오지 못했습니다.");
        }
    }
}
