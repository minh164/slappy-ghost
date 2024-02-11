using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool IsPaused {get; private set;}
    private GameOverEvent gameOverEvent;
    private GameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        gameOverEvent = GameHelper.GetGameOverEvent();
        gameStartEvent = GameHelper.GetGameStartEvent();

        // Subcribe event.
        gameOverEvent.OnGameOver += Pause;
        gameStartEvent.OnGameStart += Resume;
    }

    void OnDestroy()
    {
        gameOverEvent.OnGameOver -= Pause;
        gameStartEvent.OnGameStart -= Resume;
    }

    // Update is called once per frame
    void Update()
    {
        TogglePauseGame();
    }

    private void TogglePauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            IsPaused = ! IsPaused;
            Time.timeScale = IsPaused ? 0 : 1;
        }
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1;
    }
}
