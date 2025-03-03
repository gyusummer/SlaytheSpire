using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNode : IEquatable<DungeonNode>
{
	public int X;
	public int Y;
    public List<DungeonNode> upRoom;
    public List<DungeonNode> downRoom;
    public DungeonNode(int x, int y)
    {
        X = x;
        Y = y;
        upRoom = new List<DungeonNode>();
        downRoom = new List<DungeonNode>();
    }
    public bool HasUpStair(int x, int y)
    {
        bool has = false;

        if (upRoom.Contains(new DungeonNode(x, y))) has = true;

        return has;
    }

    public void AddUpStair(DungeonNode up)
    {
        upRoom.Add(up);
    }
    public void AddDownStair(DungeonNode down)
    {
        downRoom.Add(down);
    }
    public void SubUpStair(DungeonNode up)
    {
        upRoom.Remove(up);
    }
    public void SubDownStair(DungeonNode down)
    {
        downRoom.Remove(down);
    }
    public bool Equals(DungeonNode other)
    {
        if (X == other.X && Y == other.Y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}