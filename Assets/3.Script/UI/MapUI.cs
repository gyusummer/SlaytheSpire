using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour
{
    public GameObject Room_Button_Prefabs;
    public GameObject Map_Line_Prefabs;
    public GameObject Grid_Rooms;
    public GameObject Grid_Edges;
    public GameObject Grid_BottomLeft;
    public GameObject Grid_TopRight;
    float xGap;
    float yGap;
    Vector2 zeroPoint;
    Vector2 variability;
    Dungeon dungeon;
    List<Room> room_list;

    private void Update()
    {
        // 갈 수 있는 방 아이콘 크기 키워주기
        if(room_list != null)
        {
            for(int n = 0; n < room_list.Count - 1; n++) // 보스룸 제외를 위해 -1
            {
                if (room_list[n].DownRoom.Contains(Player.Instance.curRoom))
                {
                    room_list[n].transform.localScale = Vector3.one * 2;
                }
                else
                {
                    room_list[n].transform.localScale = Vector3.one;
                }
            }
        }
    }
    public void Init(Dungeon _dungeon)
    {
        dungeon = _dungeon;
        xGap = (Grid_TopRight.transform.position.x - Grid_BottomLeft.transform.position.x) / (DungeonMaker.Instance.Width + 1);
        yGap = (Grid_TopRight.transform.position.y - Grid_BottomLeft.transform.position.y) / (DungeonMaker.Instance.Height + 1);
        zeroPoint = Grid_BottomLeft.transform.position;
        if(Grid_BottomLeft.TryGetComponent(out RectTransform r1))
        {
            zeroPoint = zeroPoint + r1.sizeDelta / 2;
        }
        if(Room_Button_Prefabs.TryGetComponent(out RectTransform r2))
        {
            variability = r2.sizeDelta / 2;
        }
        //Debug.Log($"ZeroPoint : {zeroPoint}");
    }

    // 지도에 그려지는 아이콘(종류 구분 못함) 생성
    public void DrawRoomIcons()
    {
        room_list = dungeon.Rooms;
        foreach(Room room in room_list)
        {
            // 정렬된 그리드 위치에 생성
            //GameObject icon = Instantiate(Room_Button_Prefabs, Grid_Rooms.transform);
            room.transform.SetParent(Grid_Rooms.transform);
            room.transform.position = new Vector2(zeroPoint.x + xGap * room.X, zeroPoint.y + yGap * room.Y);

            // 약간의 위치 움직이기
            float curX = room.transform.position.x;
            float curY = room.transform.position.y;
            float newX = Random.Range(curX - variability.x, curX + variability.x);
            float newY = Random.Range(curY - variability.y, curY + variability.y);
            Vector2 newPos = new Vector2(newX, newY);
            room.transform.position = newPos;
        }
    }
    // Line Renderer가 캔버스에 안보여서 1자 모양 이미지를 생성하고 회전으로 방향 맞춰줌
    public void DrawEdges()
    {
        foreach(Room room in dungeon.Rooms)
        {
            foreach(Room upRoom in room.UpRoom)
            {
                DrawLine(room.transform.position, upRoom.transform.position);
            }
        }
        void DrawLine(Vector2 start, Vector2 end)
        {
            GameObject edge = Instantiate(Map_Line_Prefabs, Grid_Edges.transform, true);
            edge.transform.position = (start + end) * 0.5f;
            edge.TryGetComponent(out RectTransform lrt);
            
            Vector2 diff = end - start;
            float distance = diff.magnitude - 40;
            Vector2 d = lrt.sizeDelta;
            d.x = distance;
            lrt.sizeDelta = d;

            Vector2 normal = diff.normalized;
            float angle = Vector2.Angle(Vector2.right, normal);
            edge.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
