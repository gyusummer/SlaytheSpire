using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractRoom : IEquatable<AbstractRoom>
{
    int posX;
    int posY;
    public int X => posX;
    public int Y => posY;
    List<AbstractRoom> upRoom;
    List<AbstractRoom> downRoom;

    public List<AbstractRoom> UpRoom => upRoom;
    public List<AbstractRoom> DownRoom => downRoom;

    public AbstractRoom(int x, int y)
    {
        posX = x;
        posY = y;
        upRoom = new List<AbstractRoom>();
        downRoom = new List<AbstractRoom>();
    }
    public bool HasUpStair(int x, int y)
    {
        bool has = false;

        if (upRoom.Contains(new AbstractRoom(x, y))) has = true;

        return has;
    }

    public void AddUpStair(AbstractRoom up)
    {
        upRoom.Add(up);
    }
    public void AddDownStair(AbstractRoom down)
    {
        downRoom.Add(down);
    }
    public void SubUpStair(AbstractRoom up)
    {
        upRoom.Remove(up);
    }
    public void SubDownStair(AbstractRoom down)
    {
        downRoom.Remove(down);
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
