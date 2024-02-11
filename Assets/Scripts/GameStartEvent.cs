using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartEvent : MonoBehaviour
{
    public event Action OnGameStart;
    private Button restartBtnUI;

    // Start is called before the first frame update
    void Start()
    {
        restartBtnUI = (GameObject.FindGameObjectWithTag("RestartBtnUI")).GetComponent<Button>();
        restartBtnUI.onClick.AddListener(() => OnGameStart?.Invoke());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
