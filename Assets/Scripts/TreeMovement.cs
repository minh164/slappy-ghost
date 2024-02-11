using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private bool isAccessed = false;
    private PauseController pauseController;
    private StopObjectController StopController;
    private GameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        pauseController = GameHelper.GetPauseController();
        StopController = new StopObjectController();
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

    public void SetIsAccessed(Boolean value)
    {
        isAccessed = value;
    }

    public bool GetIsAccessed()
    {
        return isAccessed;
    }

    private void Suicide()
    {
        Destroy(gameObject);
    }
}
