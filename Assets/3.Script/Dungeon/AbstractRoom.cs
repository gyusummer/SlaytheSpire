using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractRoom : MonoBehaviour , IEquatable<AbstractRoom>
{
    [SerializeField]
    protected int posX;
    [SerializeField]
    protected int posY;
    public int X => posX;
    public int Y => posY;

    protected List<AbstractRoom> upRoom;
    protected List<AbstractRoom> downRoom;

    public List<AbstractRoom> UpRoom => upRoom;
    public List<AbstractRoom> DownRoom => downRoom;

    public void Init(int x, int y)
    {
        posX = x;
        posY = y;
        upRoom = new List<AbstractRoom>();
        downRoom = new List<AbstractRoom>();
    }
    public void CopyNode(DungeonNode node, AbstractRoom[,] room_arr)
    {
        posX = node.X;
        posY = node.Y;
        foreach(DungeonNode n in node.upRoom)
        {
            AddUpStair(room_arr[n.X, n.Y]);
            room_arr[n.X, n.Y].AddDownStair(this);
        }
    }
    public bool HasUpStair(AbstractRoom other)
    {
        bool has = false;

        if (upRoom.Contains(other)) has = true;

        return has;
    }

    public void AddUpStair(AbstractRoom up)
    {
        if(!upRoom.Contains(up)) upRoom.Add(up);
    }
    public void AddDownStair(AbstractRoom down)
    {
        if (!downRoom.Contains(down)) downRoom.Add(down);
    }
    public void SubUpStair(AbstractRoom up)
    {
        if (upRoom.Contains(up)) upRoom.Remove(up);
    }
    public void SubDownStair(AbstractRoom down)
    {
        if (downRoom.Contains(down)) downRoom.Remove(down);
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
