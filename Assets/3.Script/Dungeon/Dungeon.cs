using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Dungeon : Object
{
    bool[,] isThereRoom;
    DungeonNode[,] node_arr;
    Room[,] room_arr;
    private List<Room> room_list = new List<Room>();
    public GameObject Room_Prefab;
    public GameObject BossRoom_Prefab;
    public Room firstRoom = null;

    public List<Room> Rooms
    {
        get
        {
            return room_list;
        }
    }

    public Dungeon(int width, int height, GameObject prefab, GameObject bossRoomPrefab, Room _firstRoom)
    {
        isThereRoom = new bool[width, height];
        node_arr = new DungeonNode[width, height];
        room_arr = new Room[width, height];
        Room_Prefab = prefab;
        BossRoom_Prefab = bossRoomPrefab;
        //firstRoom = _firstRoom;
    }
    public Dungeon Generate(List<int[]> paths)
    {
        foreach (int[] path in paths)
        {
            for (int y = 0; y < node_arr.GetLength(1); y++)
            {
                int x = path[y];
                MakeANode(x, y);
                if (y != 0)
                {
                    MakeAPath(x, y, path[y - 1], y - 1);
                }
            }
        }
        NodeToRoom();
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
                    room_arr[x, y].CopyNode(node_arr[x, y], room_arr);
                }
            }
        }
        AddBossRoom();
        PointFirstRoom();
    }
    void PointFirstRoom()
    {
        foreach(Room r in room_list)
        {
            if(r.DownRoom.Count == 0)
            {
                r.AddDownStair(firstRoom);
            }
        }
    }
    void NodeToRoom()
    {
        for (int y = 0; y < isThereRoom.GetLength(1); y++)
        {
            for (int x = 0; x < isThereRoom.GetLength(0); x++)
            {
                if (isThereRoom[x, y])
                {
                    Room room = MakeARoom(x, y);
                    room_arr[x, y] = room;
                }
            }
        }
    }
    Room MakeARoom(int x, int y)
    {
        GameObject room = Instantiate(Room_Prefab);
        Room ar = (Room)room.AddComponent(typeof(BattleRoom));
        ar.Init(x, y);
        return ar;
    }
    void AddBossRoom()
    {
        GameObject room = Instantiate(BossRoom_Prefab);
        room.TryGetComponent(out BossRoom bossRoom);
        room_list.Add(bossRoom);
        foreach (Room ar in room_list)
        {
            if(ar.Y == room_arr.GetLength(1)-1)
            {
                ar.AddUpStair(bossRoom);
                bossRoom.AddDownStair(ar);
                //Debug.Log(bossRoom.DownRoom.Count);
            }
        }
    }
    public void MakeAPath(int TopX, int TopY, int BottomX, int BottomY)
    {
        // 교차점이 생기는지 확인
        if (isThereRoom[TopX, BottomY] && isThereRoom[BottomX, TopY])
        {
            if (node_arr[TopX, BottomY].HasUpStair(BottomX, TopY))
            {
                // 먼저 있던 경로를 삭제
                node_arr[TopX, BottomY].SubUpStair(node_arr[BottomX, TopY]);
                node_arr[BottomX, TopY].SubDownStair(node_arr[TopX, BottomY]);

                // 각자 자기 위로 올라가는 경로 추가
                node_arr[BottomX, BottomY].AddUpStair(node_arr[BottomX, TopY]);
                node_arr[BottomX, TopY].AddDownStair(node_arr[BottomX, BottomY]);

                node_arr[TopX, BottomY].AddUpStair(node_arr[TopX, TopY]);
                node_arr[TopX, TopY].AddDownStair(node_arr[TopX, BottomY]);
                return;
            }
        }

        // 경로 추가
        if (isThereRoom[TopX, TopY] && isThereRoom[BottomX, BottomY])
        {
            node_arr[BottomX, BottomY].AddUpStair(node_arr[TopX, TopY]);
            node_arr[TopX, TopY].AddDownStair(node_arr[BottomX, BottomY]);
        }
    }
    public void MakeANode(int x, int y)
    {
        if (isThereRoom[x, y] == false)
        {
            isThereRoom[x, y] = true;
            node_arr[x, y] = new DungeonNode(x, y);
            if(y == 0)
            {
                node_arr[x, y].AddDownStair(new DungeonNode(-1, -1));// 플레이어 시작지점
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
