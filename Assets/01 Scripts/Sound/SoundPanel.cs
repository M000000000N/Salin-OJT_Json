using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundPanel : MonoBehaviour
{
    [SerializeField] Button soundButton;
    [SerializeField] TextMeshProUGUI soundName;
    private bool isSoundOn;

    [SerializeField] Button vibeButton;
    [SerializeField] TextMeshProUGUI vibeName;
    private bool isVibeOn;

    [SerializeField] GameData data;

    void Start()
    {
        //soundButton.onClick.AddListener(OnClickSoundButton);
        //vibeButton.onClick.AddListener(OnClickVibeButton);
        Initioalize();
    }

    private void Initioalize()
    {
        SetSound(data.sound);
        SetVibe(data.vibe);
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
            soundName.text = "�Ҹ���";
        else
            soundName.text = "�Ҹ���";

        isSoundOn = isOn;
        data.sound = isOn;
    }

    private void SetVibe(bool isOn)
    {
        if (isOn)
            vibeName.text = "������";
        else
            vibeName.text = "������";

        isVibeOn = isOn;
        data.vibe = isOn;
    }

}
