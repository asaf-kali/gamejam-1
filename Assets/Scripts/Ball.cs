using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    void Start()
    {
        GameControl.instance.ball = this.gameObject;
    }

    void Update()
    {
        transform.position = GameControl.instance.KeepInMap(transform.position);
        if (GameControl.instance.gameOver)
            return;
        if (transform.position.y <= GameControl.instance.bottomEdge)
        {
            GameControl.instance.GameOver();
        }
    }

}