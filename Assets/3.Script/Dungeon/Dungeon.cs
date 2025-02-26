using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    bool[,] isThereRoom;
    AbstractRoom[,] room_arr;
    public List<AbstractRoom> Rooms
    {
        get
        {
            List<AbstractRoom> rooms_list = new List<AbstractRoom>();
            for (int y = 0; y < isThereRoom.GetLength(1); y++)
            {
                for (int x = 0; x < isThereRoom.GetLength(0); x++)
                {
                    if (isThereRoom[x, y])
                    {
                        rooms_list.Add(room_arr[x, y]);
                    }
                }
            }
            return rooms_list;
        }
    }

    public Dungeon(int width, int height)
    {
        isThereRoom = new bool[width, height];
        room_arr = new AbstractRoom[width, height];
    }
    //public void Prune()
    //{
    //    foreach(AbstractRoom room in Rooms)
    //    {
    //        if(room.Y != 0)
    //        {
    //            if(room.DownRoom.Count < 1)
    //            {
    //                room_arr[room.X, room.Y] = null;
    //                isThereRoom[room.X, room.Y] = false;
    //            }
    //        }
    //    }
    //}
    public void MakeAPath(int TopX, int TopY, int BottomX, int BottomY)
    {
        // 교차점이 생기는지 확인
        if (isThereRoom[TopX, BottomY] && isThereRoom[BottomX, TopY])
        {
            if (room_arr[TopX, BottomY].HasUpStair(BottomX, TopY))
            {
                // 먼저 있던 경로를 삭제
                room_arr[TopX, BottomY].SubUpStair(room_arr[BottomX, TopY]);
                room_arr[BottomX, TopY].SubDownStair(room_arr[TopX, BottomY]);

                // 각자 자기 위로 올라가는 경로 추가
                room_arr[BottomX, BottomY].AddUpStair(room_arr[BottomX, TopY]);
                room_arr[BottomX, TopY].AddDownStair(room_arr[BottomX, BottomY]);

                room_arr[TopX, BottomY].AddUpStair(room_arr[TopX, TopY]);
                room_arr[TopX, TopY].AddDownStair(room_arr[TopX, BottomY]);
                return;
            }
        }

        // 경로 추가
        if (isThereRoom[TopX, TopY] && isThereRoom[BottomX, BottomY])
        {
            room_arr[BottomX, BottomY].AddUpStair(room_arr[TopX, TopY]);
            room_arr[TopX, TopY].AddDownStair(room_arr[BottomX, BottomY]);
        }
    }
    public void MakeARoom(int x, int y)
    {
        if (isThereRoom[x, y] == false)
        {
            isThereRoom[x, y] = true;
            room_arr[x, y] = new AbstractRoom(x, y);
        }
        else return;
    }
}
