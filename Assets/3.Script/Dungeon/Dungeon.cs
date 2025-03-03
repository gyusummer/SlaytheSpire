using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon
{
    bool[,] isThereRoom;
    AbstractRoom[,] room_arr;
    private List<AbstractRoom> room_list = new List<AbstractRoom>();
    public List<AbstractRoom> Rooms
    {
        get
        {
            return room_list;
        }
    }

    public Dungeon(int width, int height)
    {
        isThereRoom = new bool[width, height];
        room_arr = new AbstractRoom[width, height];
    }
    public Dungeon Generate(List<int[]> paths)
    {
        foreach (int[] path in paths)
        {
            for (int y = 0; y < room_arr.GetLength(1); y++)
            {
                int x = path[y];
                MakeARoom(x, y);
                if (y != 0)
                {
                    MakeAPath(x, y, path[y - 1], y - 1);
                }
            }
        }
        ArrangeRoom();

        return this;
    }
    void ArrangeRoom()
    {
        for (int y = 0; y < isThereRoom.GetLength(1); y++)
        {
            for (int x = 0; x < isThereRoom.GetLength(0); x++)
            {
                if (isThereRoom[x, y])
                {
                    room_list.Add(room_arr[x, y]);
                }
            }
        }
        AddBossRoom();
    }
    void AddBossRoom()
    {
        AbstractRoom bossRoom = new AbstractRoom((int)(DungeonMaker.Instance.Width * 0.5f), DungeonMaker.Instance.Height + 1);
        room_list.Add(bossRoom);
        foreach (AbstractRoom ar in room_list)
        {
            if(ar.UpRoom.Count == 0)
            {
                ar.AddUpStair(bossRoom);
                bossRoom.AddDownStair(ar);
            }
        }
    }
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
            room_arr[x, y] = new BattleRoom(x, y);
            if(y == 0)
            {
                room_arr[x, y].AddDownStair(new AbstractRoom(-1, -1));// 플레이어 시작지점
            }
        }
        else return;
    }
    //public AbstractRoom RandomRoom(int x, int y)
    //{
    //    AbstractRoom ar;

    //    float[] roomProbs = new float[3];
    //    roomProbs[0] = 5f;
    //    roomProbs[1] = 1f;
    //    Utils.Choose(roomProbs);




    //    return ar;
    //}
}
