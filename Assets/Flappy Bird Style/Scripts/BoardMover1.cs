using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMover1 : BoardMover
{
    public BoardMover1() : base(KeyCode.LeftArrow, KeyCode.RightArrow)
    {
    }

    void Start()
    {
        GameControl.instance.player1 = this.gameObject;
    }
}