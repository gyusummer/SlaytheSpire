using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// width height grid���� ��ĭ�� �ö󰡴� ��θ� n�� ������
// ���������� �ּ� ������ �����
// ������ ��θ� ������� ������ ������
// �����ΰ� ������ ���ְ� ���� �ö󰡴� ��θ� �߰��� (Dungeon���� ó��)
public class DungeonMaker : Singleton<DungeonMaker>
{
    Dungeon dungeon;

    int height = 15;
    int width = 7;
    int pathsMin = 4;
    int startCaseMin = 2;
    public int Height => height;
    public int Width => width;
    public GameObject Room_Prefabs;

    private new void Awake()
    {
        //Debug.Log("DungeonMaker Awake");
        MakeADungeon();
        #region TEST
        if (TryGetComponent(out MapUI mapDrawer))
        {
            mapDrawer.Init(dungeon);
            mapDrawer.DrawRoomIcons();
            mapDrawer.DrawEdges();
        }
        #endregion
    }

    public Dungeon MakeADungeon()
    {
        dungeon = new Dungeon(width, height, Room_Prefabs);
        List<int[]> paths = MakePaths();
        dungeon.Generate(paths);
        return dungeon;
    }
    public List<int[]> MakePaths()
    {
        List<int[]> paths = new List<int[]>();
        for (int count = 0; count < pathsMin; count++)
        {
            int startPoint = Random.Range(0, width);
            int[] path = MakeAPath(startPoint);
            paths.Add(path);
        }
        while (!GuaranteeStartPointMin(paths, out List<int> alreadyExist))
        {
            int startPoint = Random.Range(0, width);
            if (alreadyExist.Contains(startPoint)) continue;
            int[] path = MakeAPath(startPoint);
            paths.Add(path);
        }
        return paths;
    }
    int[] MakeAPath(int startPoint)
    {
        int[] path = new int[height];
        path[0] = startPoint;
        for (int floor = 1; floor < path.Length; floor++)
        {
            int curRoom = path[floor - 1];
            int minRoom = curRoom == 0 ? 0 : curRoom - 1;
            int maxRoom = curRoom == width - 1 ? width - 1 : curRoom + 1;
            path[floor] = Random.Range(minRoom, maxRoom + 1);
        }
        return path;
    }
    bool GuaranteeStartPointMin(List<int[]> _paths, out List<int> alrExist)
    {
        List<int> startCase = new List<int>();
        foreach (int[] path in _paths)
        {
            if (!startCase.Contains(path[0])) startCase.Add(path[0]);
        }
        alrExist = startCase;
        if (alrExist.Count < startCaseMin) return false;
        else return true;
    }


    #region TEST
    public void Test()
    {
        MakeADungeon();
        List<AbstractRoom> room_list = dungeon.Rooms;
        Debug.Log(room_list.Count);
        foreach (AbstractRoom room in room_list)
        {
            foreach (AbstractRoom uproom in room.UpRoom)
            {
                Debug.DrawLine(new Vector2(room.X, room.Y), new Vector2(uproom.X, uproom.Y), Color.white, 3f);
            }
        }
    }
    #endregion
}
