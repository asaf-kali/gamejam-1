using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public float yLimit = -9f;

    void Start()
    {
        GameControl.instance.ball = this.gameObject;
    }

    void Update()
    {
        if (GameControl.instance.gameOver)
            return;
        if (transform.position.y < yLimit)
        {
            GameControl.instance.GameOver();
        }
    }

}