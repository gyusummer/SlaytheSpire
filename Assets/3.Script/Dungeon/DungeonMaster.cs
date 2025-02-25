using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public static DungeonMaster Instance = null;
    Dungeon dungeon;
    int floorMax = 15;
    int roomPerFloor = 7;
    int pathsMax = 6;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GenerateDungeon()
    {
        dungeon = new Dungeon(roomPerFloor,floorMax);
        for(int count = 0; count < pathsMax; count++)
        {
            int startPoint = Random.Range(0, 7);
            int[] path = MakeAPath(startPoint);
        }
    }
    int[] MakeAPath(int startPoint)
    {
        int[] path = new int[floorMax];
        path[0] = startPoint;
        dungeon.AddRoom(startPoint, 0, new AbstractRoom());
        for(int floor = 1; floor < path.Length; floor++)
        {
            int curRoom = path[floor - 1];
            int minRoom = curRoom == 0 ? 0 : curRoom - 1;
            int maxRoom = curRoom == 6 ? 6 : curRoom + 1;
            path[floor] = Random.Range(minRoom, maxRoom + 1);
        }
        return path;
    }


    #region Test
    List<int[]> testPath_list = new List<int[]>();
    int[] testPath;
    public void Test()
    {
        testPath = MakeAPath(Random.Range(0,7));
        string PathStr = "";
        foreach(int roomNum in testPath)
        {
            PathStr = PathStr + " " + roomNum;
        }
        Debug.Log(PathStr);
        testPath_list.Add(testPath);
    }
    private void OnDrawGizmos()
    {
        if(testPath_list.Count > 0)
        {
            foreach(int[] path in testPath_list)
            {
                Gizmos.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                for (int y = 1; y < path.Length; y++)
                {
                    int x = path[y];
                    int beforeX = path[y - 1];
                    Vector2 curPoint = new Vector2(x, y);
                    Vector2 beforePoint = new Vector2(beforeX, y - 1);
                    Gizmos.DrawLine(beforePoint, curPoint);
                }
            }
        }
    }
    #endregion
}
