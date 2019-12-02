﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMover2 : BoardMover
{
    public BoardMover2() : base(KeyCode.A, KeyCode.D)
    {
    }

    void Start()
    {
        GameControl.instance.player2 = this.gameObject;
    }

}