using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SubsceneMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private PauseController pauseController;
    private GameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        pauseController = GameHelper.GetPauseController();
        gameStartEvent = GameHelper.GetGameStartEvent();

        // Subcribe event.
        gameStartEvent.OnGameStart += Suicide;
    }

    void OnDestroy()
    {
        gameStartEvent.OnGameStart -= Suicide;
    }

    void Update()
    {
        if (pauseController.IsPaused) return;

        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void Suicide()
    {
        Destroy(gameObject);
    }
}
