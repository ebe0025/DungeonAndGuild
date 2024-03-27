using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    enum NodeType
    {
        NONE,
        ENEMY_ROOM,
        BOX_ROOM,
        HEAL_ROOM,
        BOSS_ROOM
    }

    public class Node 
    {
        int x, y;
    }
}
