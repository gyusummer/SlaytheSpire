using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractRoom : IEquatable
{
    public int posX;
    public int posY;
    public List<AbstractRoom> ParentRoom;
    public List<AbstractRoom> childRoom;

    public AbstractRoom()
    {
        ParentRoom = new List<AbstractRoom>();
        childRoom = new List<AbstractRoom>();
    }

    public void AddPath(AbstractRoom room)
    {
        childRoom.Add(room);
    }
    public bool Equals(AbstractRoom other)
    {
        if (posX == other.posX && posY == other.posY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
