using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public bool IsCollided {get; private set;}
    public AudioSource jumpSound;
    public AudioSource collidedSound;
    public float speedUp = 3.0f;
    private float velocity;
    private Vector3 initPosition;
    private StopObjectController StopController;
    private PauseController pauseController;
    private GameStartEvent gameStartEvent;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        velocity = transform.position.y;
        StopController = new StopObjectController();
        pauseController = GameHelper.GetPauseController();
        gameStartEvent = GameHelper.GetGameStartEvent();
        jumpSound = Instantiate(jumpSound);
        collidedSound = Instantiate(collidedSound);

        // Subcribe event.
        gameStartEvent.OnGameStart += SetupOnGameStart;
    }

    void OnDestroy()
    {
        gameStartEvent.OnGameStart -= SetupOnGameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseController.IsPaused) {
            return;
        } else {
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            velocity = speedUp;
            jumpSound.Play();
        }

        transform.Translate(0, velocity * Time.deltaTime, 0);

        // Determines whether object is grounded.
        if (transform.position.y <= 0.5f) {
            velocity = 0;
        } else {
            velocity -= 0.02f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collidedSound.Play();
        IsCollided = true;
    }

    private void SetupOnGameStart()
    {
        transform.position = initPosition;
        IsCollided = false;
    }
}
