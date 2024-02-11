using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    private GameOverEvent gameOverEvent;
    public GameOverEvent GameOverEvent
    {
        get {return gameOverEvent;}
        private set {gameOverEvent = value;}
    }

    public event Action OnGameStart;
    public bool isOver = false;
    private bool isPaused = false;
    private GameObject ghost;
    private GhostController ghostScript;
    public GameObject spawnManager;
    private int points = 0;
    private TMP_Text pointsUI;
    private Button restartBtnUI;

    // Start is called before the first frame update
    void Start()
    {

        ghost = GameObject.FindGameObjectWithTag("Player");
        ghostScript = ghost.GetComponent<GhostController>();
        pointsUI = (GameObject.FindGameObjectWithTag("PointsUI")).GetComponent<TMP_Text>();
        restartBtnUI = (GameObject.FindGameObjectWithTag("RestartBtnUI")).GetComponent<Button>();
        restartBtnUI.onClick.AddListener(() => RestartGame());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tree = GameObject.FindGameObjectWithTag("Respawn");
        // SetGameOver();
        if (tree) {
            // IncreasePoints(tree);
        }

        
    }

    public void GameLost()
    {
        
        
        // OnGameOver?.Invoke();

        
    }

    // private void SetGameOver()
    // {
    //     gameOver = ghostScript.GetIsCollided();
    //     if (gameOver) {
    //         Destroy(GameObject.FindGameObjectWithTag("SpawnManager"));
    //     }
    // }

    private void RestartGame()
    {
        isOver = false;

        // Destroy all trees.
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject tree in trees) {
            Destroy(tree);
        }

        // Set initial position for ghost.
        // ghostScript.SetIsCollided(false);
        // ghost.transform.position = ghostScript.GetInitPosition();

        // Init SpawnManager.
        Instantiate(
            spawnManager,
            new Vector3(12, transform.position.y, transform.position.z),
            spawnManager.transform.rotation
        );

        // Set points to zero.
        points = 0;
        pointsUI.text = points.ToString();
    }
}
