using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int points = 0;
    private TMP_Text pointsUI;
    private GameOverEvent gameOverEvent;
    private GameStartEvent gameStartEvent;
    private GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        pointsUI = (GameObject.FindGameObjectWithTag("PointsUI")).GetComponent<TMP_Text>();
        ghost = GameObject.FindGameObjectWithTag("Player");
        gameOverEvent = GameHelper.GetGameOverEvent();
        gameStartEvent = GameHelper.GetGameStartEvent();

        // Subcribe event.
        gameStartEvent.OnGameStart += SetZero;
    }

    void OnDestroy()
    {
        gameStartEvent.OnGameStart -= SetZero;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject tree = GameObject.FindGameObjectWithTag("Respawn");

        if (tree) {
            IncreasePoints(tree);
        }
    }

    private void IncreasePoints(GameObject tree)
    {
        TreeMovement treeScript = tree.GetComponent<TreeMovement>();

        // Plusing point conditions:
        // - Game is not over (ghost has not grounded or collided any tree).
        // - The tree is passed the ghost.
        // - Each tree which be passed only plus once point.
        if (
            ! gameOverEvent.IsOver
            && tree.transform.position.x < ghost.transform.position.x
            && ! treeScript.GetIsAccessed()
        ) {
            // Plus point.
            points += 1;
            pointsUI.text = points.ToString();
            
            // Mark "tree" object is plused point.
            treeScript.SetIsAccessed(true);

            Debug.Log(points);
        }
    }

    private void SetZero()
    {
        points = 0;
        pointsUI.text = points.ToString();
    }
}
