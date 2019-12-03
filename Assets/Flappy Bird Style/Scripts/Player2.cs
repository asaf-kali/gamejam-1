using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : PlayerController
{
    public Player2() : base(KeyCode.A, KeyCode.D)
    {
    }

    void Start()
    {
        GameControl.instance.player2 = this.gameObject;
    }

}