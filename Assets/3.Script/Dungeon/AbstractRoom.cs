using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractRoom
{
    public List<AbstractRoom> reachableRoom;

    public void AddPath(AbstractRoom room)
    {
        reachableRoom.Add(room);
    }
}
