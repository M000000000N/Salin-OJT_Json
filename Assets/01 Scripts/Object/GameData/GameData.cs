using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Data", menuName = "Data/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public string server;
    public int hp;
    public int score;
    public bool sound;
    public bool vibe;

    public void Print()
    {
        Debug.Log($"스크립터블\nServer : {server}\nHp : {hp}\nScore : {score}\nSound : {sound}\nVibe : {vibe}");
    }
}
