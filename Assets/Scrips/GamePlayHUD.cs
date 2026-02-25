using TMPro;
using UnityEngine;

public class GameplayHUD : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text moneyText;

    void Update()
    {
        //if (GameManager.I.CurrentState != GameManager.State.Playing) return;

        timerText.text = $"Time: {Mathf.CeilToInt(GameManager.I.timeRemaining)}";
        moneyText.text = $"Money: {GameManager.I.money}";
    }
}