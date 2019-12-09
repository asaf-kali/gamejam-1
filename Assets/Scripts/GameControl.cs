using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text scoreText;
    public GameObject gameOverDisplay;
    public GameObject globalLight;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public Vector2 gravity;

    private int score = 0;
    public bool gameOver { get; private set; }
    public float scrollSpeed;
    public float leftEdge;
    public float rightEdge;
    public float topEdge;
    public float bottonEdge;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
        gameOver = false;
        Physics2D.gravity = gravity;
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
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public Vector2 KeepInMap(Vector2 position)
    {
        if (position.x <= leftEdge)
            position.x = leftEdge;
        if (position.x >= rightEdge)
            position.x = rightEdge;
        if (position.y <= bottonEdge)
            position.y = bottonEdge;
        if (position.y >= topEdge)
            position.y = topEdge;
        return position;
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
        Debug.Log("Game over");
        gameOver = true;
        Physics2D.gravity = Vector2.zero;
        globalLight.SetActive(false);
        gameOverDisplay.SetActive(true);
    }

}
