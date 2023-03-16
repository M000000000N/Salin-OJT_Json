using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUI : MonoBehaviour
{
    [SerializeField] GameObject hpSprite;
    [SerializeField] Transform content;
    Stack<GameObject> spriteList;

    void Start()
    {
        spriteList = new Stack<GameObject>();
        for (int i = 0; i < GameData.Instance.Hp; i++)
        {
            GameObject sprite = Instantiate(hpSprite, content);
            spriteList.Push(sprite);
        }
    }

    public void Attected()
    {
        GameObject sprite = spriteList.Pop();
        sprite.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
