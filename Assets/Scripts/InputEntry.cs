using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InputEntry 
{
    public int score;
    public int kill;

    public InputEntry(int score, int kill)
    {
        this.score = score;
        this.kill = kill;
    }
}
