using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] treePrefabs;
    private float topY = 6.8f;
    private float botY = 0.5f;
    private StopObjectController StopController;
    private PauseController pauseController;

    // Start is called before the first frame update
    void Start()
    {
        StopController = new StopObjectController();
        pauseController = GameHelper.GetPauseController();

        InvokeRepeating("SpawnTrees", 1.0f, 1.0f);
    }

    private void SpawnTrees()
    {
        if (pauseController.IsPaused) return;

        // Get random tree.
        GameObject tree = treePrefabs[Random.Range(0, treePrefabs.Length)];
        
        // Get up/down position Y.
        float[] randomY = {topY, botY};
        float positionY = randomY[Random.Range(0, randomY.Length)];
        // If position Y is top, tree will be rotate 180.
        tree.transform.rotation = Quaternion.Euler(
            positionY == topY ? 180 : 0, tree.transform.rotation.y, tree.transform.rotation.z
        );

        // Get scale Y.
        float scaleY = Random.Range(0.3f, 0.7f);
        tree.transform.localScale = new Vector3(
            tree.transform.localScale.x, scaleY, tree.transform.localScale.z
        );

        Instantiate(
            tree,
            new Vector3(transform.position.x, positionY, transform.position.z),
            tree.transform.rotation
        );
    }
}
