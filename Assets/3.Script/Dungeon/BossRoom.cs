using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : AbstractRoom
{
    protected override void Awake()
    {
        upRoom = new List<AbstractRoom>();
        downRoom = new List<AbstractRoom>();
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
