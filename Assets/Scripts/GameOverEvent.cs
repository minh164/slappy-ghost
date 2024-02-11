using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
{
    public event Action OnGameOver;
    public bool IsOver {get; private set;}
    public AudioSource overSound;
    private GameObject ghost;
    private GhostController ghostScript;
    private GameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.FindGameObjectWithTag("Player");
        ghostScript = ghost.GetComponent<GhostController>();
        gameStartEvent = GameHelper.GetGameStartEvent();
        overSound = Instantiate(overSound);

        // Subcribe event.
        gameStartEvent.OnGameStart += UnOver;
    }

    void OnDestroy()
    {
        gameStartEvent.OnGameStart -= UnOver;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        if (ghostScript.IsCollided && ! IsOver) {
            overSound.Play();
            OnGameOver?.Invoke();
            IsOver = true;
            Debug.Log("game over!");
        }
    }

    private void UnOver()
    {
        IsOver = false;
    }
}
