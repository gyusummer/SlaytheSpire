using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : MonoBehaviour
{
    public static DungeonMaster Instance = null;
    Dungeon dungeon;

    int height = 15;
    int width = 7;
    int pathsMin = 6;
    int startCaseMin = 2;
    
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
    public List<int[]> MakePaths()
    {
        List<int[]> paths = new List<int[]>();
        for(int count = 0; count < pathsMin; count++)
        {
            int startPoint = Random.Range(0, width);
            int[] path = MakeAPath(startPoint);
            paths.Add(path);
        }
        while(!GuaranteeStartPointMin(paths, out List<int> alreadyExist))
        {
            int startPoint = Random.Range(0, width);
            if (alreadyExist.Contains(startPoint)) continue;
            int[] path = MakeAPath(startPoint);
            paths.Add(path);
        }
    }
    int[] MakeAPath(int startPoint)
    {
        int[] path = new int[height];
        path[0] = startPoint;
        dungeon.AddRoom(startPoint, 0, new AbstractRoom());
        for(int floor = 1; floor < path.Length; floor++)
        {
            int curRoom = path[floor - 1];
            int minRoom = curRoom == 0 ? 0 : curRoom - 1;
            int maxRoom = curRoom == width - 1 ? width - 1 : curRoom + 1;
            path[floor] = Random.Range(minRoom, maxRoom + 1);
        }
        return path;
    }
    bool GuaranteeStartPointMin(List<int> _paths, out List<int> alrExist)
    {
        List<int> startCase = new List<int>();
        foreach(int[] path in _paths)
        {
            if (!startCase.Contains(path[0])) startCase.Add(path[0]);
        }
        alrExist = startCase;
        if (alrExist.Count < startCaseMin) return false;
        else return true;
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
