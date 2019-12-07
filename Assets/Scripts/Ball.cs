using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    void Start()
    {
        GameControl.instance.ball = this.gameObject;
    }
}