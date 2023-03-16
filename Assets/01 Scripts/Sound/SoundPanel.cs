using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundPanel : MonoBehaviour
{
    [Header("»ç¿îµå")]
    [SerializeField] Button soundButton;
    [SerializeField] TextMeshProUGUI soundName;

    [Header("Áøµ¿")]
    [SerializeField] Button vibeButton;
    [SerializeField] TextMeshProUGUI vibeName;
    private bool isVibeOn;

    void Awake()
    {
        //soundButton.onClick.AddListener(OnClickSoundButton);
        //vibeButton.onClick.AddListener(OnClickVibeButton);
    }

    private void Start()
    {
        Initioalize();
    }

    private void Initioalize()
    {
        SetSound(GameData.Instance.Sound);
        SetVibe(GameData.Instance.Vibe);
    }

    public void OnClickSoundButton()
    {
        SetSound(!GameData.Instance.Sound);
    }

    public void OnClickVibeButton()
    {
        SetVibe(!GameData.Instance.Vibe);
    }
   
    private void SetSound(bool isOn)
    {
        if (isOn)
        {
            soundName.text = "¼Ò¸®ÄÔ";
            SoundManager.Instance.SetVolume(1);
        }
        else
        {
            soundName.text = "¼Ò¸®²û";
            SoundManager.Instance.SetVolume(0);
        }
        GameData.Instance.Sound = isOn;
    }

    private void SetVibe(bool isOn)
    {
        if (isOn)
            vibeName.text = "Áøµ¿ÄÔ";
        else
            vibeName.text = "Áøµ¿²û";

        GameData.Instance.Vibe = isOn;
    }
}
