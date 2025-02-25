using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    bool[,] isThereRoom;
    AbstractRoom[,] room_arr;
    public AbstractRoom[,] Rooms
    {
        get
        {
            return room_arr;
        }
    }

    public Dungeon(int width,int floors)
    {
        isThereRoom = new bool[width, floors];
        room_arr = new AbstractRoom[width, floors];
    }

    public void AddRoom(int x, int y, AbstractRoom room)
    {
        if (isThereRoom[x, y] == false)
        {
            isThereRoom[x, y] = true;
            room_arr[x, y] = room;
        }
    }
}
