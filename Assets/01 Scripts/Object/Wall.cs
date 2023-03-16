using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Bullet"))
        {
            GameManager.Instance.Scored();
            gameObject.SetActive(false);
            SoundManager.Instance.PlaySound(1);

        }
        else if (other.tag.Equals("Player"))
        {
            GameManager.Instance.Attected();
            SoundManager.Instance.PlaySound(2);
            if(GameData.Instance.Vibe)
            Handheld.Vibrate();
        }
    }
}
