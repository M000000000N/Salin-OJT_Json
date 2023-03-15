using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : SingletonBehaviour<GameData>
{
    public string server;
    public int hp;
    public int score;
    public bool sound;
    public bool vibe;
}