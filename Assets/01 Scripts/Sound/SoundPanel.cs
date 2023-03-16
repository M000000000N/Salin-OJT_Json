using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundPanel : MonoBehaviour
{
    [Header("����")]
    [SerializeField] Button soundButton;
    [SerializeField] TextMeshProUGUI soundName;
    private bool isSoundOn;

    [Header("����")]
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
        GameData.Instance.Sound = isOn;
    }

    private void SetVibe(bool isOn)
    {
        if (isOn)
            vibeName.text = "������";
        else
            vibeName.text = "������";

        isVibeOn = isOn;
        GameData.Instance.Vibe = isOn;
    }

}
