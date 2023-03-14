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
    // Start is called before the first frame update
    void Start()
    {
        soundButton.onClick.AddListener(OnClickSoundButton);
        vibeButton.onClick.AddListener(OnClickVibeButton);
        Initioalize();
    }
    private void Initioalize()
    {
        soundName.text = "�Ҹ���";
        isSoundOn = true;
        vibeName.text = "������";
        isVibeOn = true;
    }
    public void OnClickSoundButton()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
            soundName.text = "�Ҹ���";
            AudioListener.volume = 0;
        }
        else
        {
            isSoundOn = true;
            soundName.text = "�Ҹ���";
            AudioListener.volume = 1;
        }
    }
    public void OnClickVibeButton() // ���� ���� �ѱ�
    {
        if (isVibeOn)
        {
            isVibeOn = false;
            vibeName.text = "������";
            // Handheld.Vibrate();
        }
        else
        {
            isVibeOn = true;
            vibeName.text = "������";
        }
    }

}
