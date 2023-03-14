using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataParcing : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public string server;
        public int hp;
        public int score;
        public bool sound;
        public bool vibe;

        public void printNumbers()
        {
            Debug.Log($"server : {server}, hp : {hp}, score : {score}, sound : {sound}, sound : {sound}, vibe : {vibe}");
        }

    }

    void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Json/GameData");
        if(textAsset != null)
        {
            // 플레이어 데이터가 존재하는 경우
            GameData lt = JsonUtility.FromJson<GameData>(textAsset.text);
            lt.printNumbers();
        }
        else
        {
            // 플레이어 데이터가 존재하지 않는 경우 (최초실행)

        }
    }
}
