using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stateText;

    public void SetUI()
    {
        stateText.text =
            $"Server : {GameData.Instance.Server}\n" +
            $"Hp : {GameData.Instance.Hp}\n" +
            $"Score : {GameData.Instance.Score}";
            //$"Sound : {GameData.Instance.Sound}\n" +
            //$"Vibe : {GameData.Instance.Vibe}";
    }
}
