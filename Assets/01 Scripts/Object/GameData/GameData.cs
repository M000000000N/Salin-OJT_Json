using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData : SingletonBehaviour<GameData>
{
    public string Server;
    public int Hp;
    public int Score;
    public bool Sound;
    public bool Vibe;
    //public string Server { get { return server; } set { server = value; SaveData(); } }
    //public int Hp { get { return hp; } set { hp = value; SaveData(); } }
    //public int Score { get { return score; } set { score = value; SaveData(); } }
    //public bool Sound { get { return sound; } set { sound = value; SaveData(); } }
    //public bool Vibe { get { return vibe; } set { vibe = value; SaveData(); } }

    //private string server;
    //private int hp;
    //private int score;
    //private bool sound;
    //private bool vibe;
}