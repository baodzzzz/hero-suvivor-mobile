using Script.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int level;
    public int hp;
    public float[] position;

    public PlayerData(Player player)
    {
        level = player.level;
        hp = player.hp;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}

