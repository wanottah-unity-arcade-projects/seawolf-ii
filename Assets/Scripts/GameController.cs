
using System.Collections;
using UnityEngine;

//
// Sea Wolf v2021.02.03
//
// 2021.01.24
//

public class GameController : MonoBehaviour
{
    public static GameController gameController;

    public Transform gameOverText;

    private int player1Score;
    private int player2Score;
 
    private int highScore;

    private float gameTimer;

    [HideInInspector] public bool topLeftShipActive;
    [HideInInspector] public bool topRightShipActive;
    [HideInInspector] public bool bottomRightShipActive;
    [HideInInspector] public bool bottomLeftShipActive;

    [HideInInspector] public bool canPlay;
    [HideInInspector] public bool gameOver;

    [HideInInspector] public bool twoPlayer;


    private void Awake()
    {
        gameController = this;
    }


    void Start()
    {
        StartUp();
    }


    void Update()
    {
        GameLoop();
    }


    private void StartUp()
    {
        canPlay = false;
        gameOver = true;

        twoPlayer = false;

        DisableShips();

        DisableSeaMines();

        Player1Controller.player1.periscopeReticle.gameObject.SetActive(false);
        Player2Controller.player2.periscopeReticle.gameObject.SetActive(false);

        Player1Controller.player1.ReloadAmmo(false);
        Player2Controller.player2.ReloadAmmo(false);

        player1Score = 0;
        player2Score = 0;

        highScore = 0;

        ScoreController.scoreController.InitialiseScores();

        gameTimer = 0f;

        UpdateTimer();

        gameOverText.gameObject.SetActive(true);
    }


    private void DisableShips()
    {
        topLeftShipActive = false;
        topRightShipActive = false;
        bottomLeftShipActive = false;
        bottomRightShipActive = false;

        for (int i = 0; i < TopLeftShipSpawner.spawner.ship.Length; i++)
        {
            TopLeftShipSpawner.spawner.ship[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < TopRightShipSpawner.spawner.ship.Length; i++)
        {
            TopRightShipSpawner.spawner.ship[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < BottomLeftShipSpawner.spawner.ship.Length; i++)
        {
            BottomLeftShipSpawner.spawner.ship[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < BottomRightShipSpawner.spawner.ship.Length; i++)
        {
            BottomRightShipSpawner.spawner.ship[i].gameObject.SetActive(false);
        }
    }


    private void DisableSeaMines()
    {
        SeaMineSpawner1.spawner.seaMineCount = -1;
        SeaMineSpawner2.spawner.seaMineCount = -1;
        SeaMineSpawner3.spawner.seaMineCount = -1;
        SeaMineSpawner4.spawner.seaMineCount = -1;

        for (int i = 0; i < SeaMineSpawner1.spawner.seaMine.Length; i++)
        {
            SeaMineSpawner1.spawner.seaMine[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SeaMineSpawner2.spawner.seaMine.Length; i++)
        {
            SeaMineSpawner2.spawner.seaMine[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SeaMineSpawner3.spawner.seaMine.Length; i++)
        {
            SeaMineSpawner3.spawner.seaMine[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < SeaMineSpawner4.spawner.seaMine.Length; i++)
        {
            SeaMineSpawner4.spawner.seaMine[i].gameObject.SetActive(false);
        }
    }


    private void Initialise()
    {
        DisableShips();

        DisableSeaMines();

        player1Score = 0;
        player2Score = 0;
        
        ScoreController.scoreController.InitialiseScores();
 
        gameTimer = 70f;

        UpdateTimer();

        Player1Controller.player1.Initialise();

        if (twoPlayer)
        {
            Player2Controller.player2.Initialise();
        }

        gameOverText.gameObject.SetActive(false);

        StartCoroutine(StartDelay());
    }


    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);

        gameOver = false;

        canPlay = true;
    }


    private void GameLoop()
    {
        if (!gameOver)
        {
            gameTimer -= Time.deltaTime;

            if (gameTimer >= 0)
            {
                UpdateTimer();
            }

            else
            {
                canPlay = false;

                twoPlayer = false;

                gameOver = true;

                gameOverText.gameObject.SetActive(true);
            }
        }

        else
        {
            UpdateHighScore();

            KeyboardController();
        }
    }


    private void KeyboardController()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartOnePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartTwoPlayer();
        }
    }


    private void StartOnePlayer()
    {
        Initialise();
    }


    private void StartTwoPlayer()
    {
        twoPlayer = true;

        Initialise();
    }


    public void UpdatePlayer1Score(int points)
    {
        player1Score += points;

        ScoreController.scoreController.UpdateScoreDisplay(player1Score, ScoreController.PLAYER_1);
    }


    public void UpdatePlayer2Score(int points)
    {
        player2Score += points;

        ScoreController.scoreController.UpdateScoreDisplay(player2Score, ScoreController.PLAYER_2);
    }


    private void UpdateHighScore()
    {
        if (player1Score > highScore)
        {
            highScore = player1Score;
        }

        if (player2Score > highScore)
        {
            highScore = player2Score;
        }

        ScoreController.scoreController.UpdateScoreDisplay(highScore, ScoreController.HIGH_SCORE);
    }


    private void UpdateTimer()
    {
        TimerController.timerController.UpdateTimerDisplay((int)gameTimer);
    }


} // end of class
