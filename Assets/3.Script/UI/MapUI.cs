using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: �������̶� ���� Ǯ������ �����

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
    List<AbstractRoom> room_list;

    private void Update()
    {
        if(room_list != null)
        {
            foreach(AbstractRoom room in room_list)
            {
                if (room.DownRoom.Contains(Player.Instance.curRoom))
                {
                    room.Icon.transform.localScale = Vector3.one * 2;
                }
                else
                {
                    room.Icon.transform.localScale = Vector3.one;
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

    // ������ �׷����� ������(���� ���� ����) ����
    public void DrawRoomIcons()
    {
        room_list = dungeon.Rooms;
        foreach(AbstractRoom room in room_list)
        {
            // ���ĵ� �׸��� ��ġ�� ����
            GameObject icon = Instantiate(Room_Button_Prefabs, Grid_Rooms.transform);
            icon.transform.position = new Vector2(zeroPoint.x + xGap * room.X, zeroPoint.y + yGap * room.Y);

            // �ణ�� ��ġ �����̱�
            float curX = icon.transform.position.x;
            float curY = icon.transform.position.y;
            float newX = Random.Range(curX - variability.x, curX + variability.x);
            float newY = Random.Range(curY - variability.y, curY + variability.y);
            Vector2 newPos = new Vector2(newX, newY);
            icon.transform.position = newPos;
            room.SetIcon(icon);
        }
    }
    // Line Renderer�� ĵ������ �Ⱥ����� 1�� ��� �̹����� �����ϰ� ȸ������ ���� ������
    public void DrawEdges()
    {
        foreach(AbstractRoom room in dungeon.Rooms)
        {
            foreach(AbstractRoom upRoom in room.UpRoom)
            {
                DrawLine(room.Icon.transform.position, upRoom.Icon.transform.position);
            }
        }
        void DrawLine(Vector2 start, Vector2 end)
        {
            GameObject edge = Instantiate(Map_Line_Prefabs, Grid_Edges.transform, true);
            edge.transform.position = (start + end) * 0.5f;
            edge.TryGetComponent(out RectTransform lrt);
            
            Vector2 diff = end - start;
            float distance = diff.magnitude;
            Vector2 d = lrt.sizeDelta;
            d.x = distance;
            lrt.sizeDelta = d;

            Vector2 normal = diff.normalized;
            float angle = Vector2.Angle(Vector2.right, normal);
            edge.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
