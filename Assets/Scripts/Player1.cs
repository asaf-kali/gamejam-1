﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : PlayerController
{
    public Player1() : base(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow)
    {
    }

}