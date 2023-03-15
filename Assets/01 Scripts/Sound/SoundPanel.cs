using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SoundPanel : MonoBehaviour
{
    [Header("»ç¿îµå")]
    [SerializeField] Button soundButton;
    [SerializeField] TextMeshProUGUI soundName;
    private bool isSoundOn;

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
        SetSound(GameData.Instance.sound);
        SetVibe(GameData.Instance.vibe);
    }

    public void OnClickSoundButton()
    {
        SetSound(!isSoundOn);
    }

    public void OnClickVibeButton()
    {
        SetVibe(!isVibeOn);
    }
   
    private void SetSound(bool isOn)
    {
        if (isOn)
            soundName.text = "¼Ò¸®ÄÔ";
        else
            soundName.text = "¼Ò¸®²û";

        isSoundOn = isOn;
        GameData.Instance.sound = isOn;
    }

    private void SetVibe(bool isOn)
    {
        if (isOn)
            vibeName.text = "Áøµ¿ÄÔ";
        else
            vibeName.text = "Áøµ¿²û";

        isVibeOn = isOn;
        GameData.Instance.vibe = isOn;
    }

}
