using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public enum State { MainMenu, Playing, GameOver }
    public State CurrentState { get; private set; }

    [Header("UI References")]
    public GameObject mainMenuUI;
    public GameObject gameplayHUD;
    public GameObject gameOverUI;

    [Header("Player Control")]
    [Tooltip("Drag the script that moves the player (movement controller) here")]
    public MonoBehaviour playerMovementScript;

    [Header("Game Values")]
    public float runDuration = 30f;
    public float timeRemaining;
    public int money;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
    }

    void Start()
    {
        SetState(State.MainMenu);
    }

    void Update()
    {
        if (CurrentState != State.Playing) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();
        }
    }

    void SetState(State newState)
    {
        CurrentState = newState;

        // UI
        mainMenuUI.SetActive(newState == State.MainMenu);
        gameplayHUD.SetActive(newState == State.Playing);
        gameOverUI.SetActive(newState == State.GameOver);

        // Pause / Resume game time
        Time.timeScale = (newState == State.Playing) ? 1f : 0f;

        // Enable / Disable player movement
        if (playerMovementScript != null)
            playerMovementScript.enabled = (newState == State.Playing);
    }

    public void GoToMainMenu()
    {
        SetState(State.MainMenu);
    }

    public void StartGame()
    {
        money = 0;
        timeRemaining = runDuration;
        SetState(State.Playing);
    }

    public void EndGame()
    {
        SetState(State.GameOver);
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /*public static GameManager I;

    public enum State { MainMenu, Playing, GameOver }
    public State CurrentState { get; private set; }

    [Header("References")]
    public GameObject mainMenuUI;
    public GameObject gameplayHUD;
    public GameObject gameOverUI;

    [Header("Game Values")]
    public float runDuration = 30f;
    public float timeRemaining;
    public int money;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;
    }

    void Start()
    {
        GoToMainMenu();
    }

    void Update()
    {
        if (CurrentState != State.Playing) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndGame();
        }
    }

    public void GoToMainMenu()
    {
        CurrentState = State.MainMenu;
        mainMenuUI.SetActive(true);
        gameplayHUD.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void StartGame()
    {
        money = 0;
        timeRemaining = runDuration;

        CurrentState = State.Playing;
        mainMenuUI.SetActive(false);
        gameplayHUD.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void EndGame()
    {
        CurrentState = State.GameOver;
        gameplayHUD.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }*/
}
