using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;         // A reference to our game control script so we can access it statically.
    public Text scoreText;                      // A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;             // A reference to the object that displays the text which appears when the player dies.

    public GameObject player1;
    public GameObject player2;
    public GameObject ball;

    private int score = 0;                      // The player's score.
    public bool gameOver = false;               // Is the game over?
    public const float scrollSpeed = 5.0f; 
    public const float scrollSpeedBgMid = -2.5f;
    public const float scrollSpeedBgFar = -1.0f;
    public const float scrollSpeedFg = -10.0f;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        InitPlayers();
    }

    void InitPlayers()
    {
        InitPlayer2();
        player1.AddComponent<Player1>();
        player2.AddComponent<Player2>();
    }

    void InitPlayer2()
    {
        Vector2 position = player1.transform.position;
        position.x *= -1;
        instance.player2 = Instantiate(player1, position, player1.transform.rotation);
    }

    void Update()
    {
        // If the game is over and the player has pressed some input...
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            // ...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BallPass()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        // Activate the game over text.
        Debug.Log("Game over");
        // gameOvertext.SetActive(true);
        // Set the game to be over.
        gameOver = true;
    }
}
