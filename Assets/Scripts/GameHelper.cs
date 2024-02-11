using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    private static GameObject gameplay;
    private static GameOverEvent gameOverEvent;
    private static GameStartEvent gameStartEvent;
    private static PauseController pauseController;

    public static GameObject GetGameplay()
    {
        if (! gameplay) gameplay = GameObject.FindGameObjectWithTag("Gameplay");
        
        return gameplay;
    }

    public static GameOverEvent GetGameOverEvent()
    {
        if (! gameOverEvent) {
            gameOverEvent = GetGameplay().GetComponent<GameOverEvent>();
        }

        return gameOverEvent;
    }

    public static GameStartEvent GetGameStartEvent()
    {
        if (! gameStartEvent) {
            gameStartEvent = GetGameplay().GetComponent<GameStartEvent>();
        }

        return gameStartEvent;
    }

    public static PauseController GetPauseController()
    {
        if (! pauseController) {
            pauseController = GetGameplay().GetComponent<PauseController>();
        }

        return pauseController;
    }
}
