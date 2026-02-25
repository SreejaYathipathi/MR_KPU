using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text summaryText;

    void OnEnable()
    {
        if (summaryText == null)
        {
            Debug.LogError("GameOverUI: summaryText is NOT assigned in the Inspector.");
            return;
        }

        if (GameManager.I == null)
        {
            summaryText.text = "Money Collected: 0";
            Debug.LogError("GameOverUI: GameManager.I is null. Make sure GameManager exists in scene.");
            return;
        }

        summaryText.text = $"Money Collected: {GameManager.I.money}";
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
            GameManager.I.RestartGame();

        if (OVRInput.GetDown(OVRInput.Button.Four))
            GameManager.I.QuitGame();
    }
}