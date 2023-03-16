using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] HpUI hpUI;
    [SerializeField] StateUI stateUI;

    public void Attected()
    {
        GameData.Instance.Hp--;
        hpUI.Attected();
        stateUI.SetUI();
    }
    
    public void Scored()
    {
        GameData.Instance.Score += 100;
        stateUI.SetUI();
    }
}
