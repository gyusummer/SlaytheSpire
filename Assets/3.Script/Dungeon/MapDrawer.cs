using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDrawer : MonoBehaviour
{
    public GameObject Room_Button_Prefabs;
    public GameObject grid;
    public GameObject Grid_BottomLeft;
    public GameObject Grid_TopRight;
    float xGap;
    float yGap;
    Vector2 zeroPoint;
    Vector2 variability;
    Dungeon dungeon;

    public void Init(Dungeon _dungeon)
    {
        dungeon = _dungeon;
        xGap = (Grid_TopRight.transform.position.x - Grid_BottomLeft.transform.position.x) / (DungeonMaker.Instance.Width + 1);
        yGap = (Grid_TopRight.transform.position.y - Grid_BottomLeft.transform.position.y) / (DungeonMaker.Instance.Height + 1);
        zeroPoint = Grid_BottomLeft.transform.position;
        if(Grid_BottomLeft.TryGetComponent<RectTransform>(out RectTransform r1))
        {
            zeroPoint = zeroPoint + r1.sizeDelta / 2;
        }
        if(Room_Button_Prefabs.TryGetComponent<RectTransform>(out RectTransform r2))
        {
            variability = r2.sizeDelta / 2;
        }
        Debug.Log($"ZeroPoint : {zeroPoint}");
    }
    public void DrawRoomIcons()
    {
        List<AbstractRoom> room_list = dungeon.Rooms;
        foreach(AbstractRoom room in room_list)
        {
            // 정렬된 그리드 위치에 생성
            GameObject icon = Instantiate(Room_Button_Prefabs, grid.transform);
            icon.transform.position = new Vector2(zeroPoint.x + xGap * room.X, zeroPoint.y + yGap * room.Y);

            // 약간의 위치 움직이기
            float curX = icon.transform.position.x;
            float curY = icon.transform.position.y;
            float newX = Random.Range(curX - variability.x, curX + variability.x);
            float newY = Random.Range(curY - variability.y, curY + variability.y);
            icon.transform.position = new Vector2(newX, newY);
        }
    }
}
