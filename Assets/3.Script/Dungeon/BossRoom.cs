using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : Room
{
    protected override void Awake()
    {
        upRoom = new List<Room>();
        downRoom = new List<Room>();
    }
    private new void Start()
    {
        base.Start();
        roomType = RoomType.Battle;
    }

    protected override void DrawCircle()
    {
        // Don't Do AnyThing;
    }
}
