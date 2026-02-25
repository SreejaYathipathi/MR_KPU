using UnityEngine;

public class MainMenuInput : MonoBehaviour
{
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
            GameManager.I.StartGame();

        if (OVRInput.GetDown(OVRInput.Button.Four))
            GameManager.I.QuitGame();
    }
}
