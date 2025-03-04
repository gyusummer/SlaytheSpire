using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMaster : Singleton<DungeonMaster>
{
    public GameObject RoomContents;
    public BattleManger battleManager;
    public void PrepareRoom(AbstractRoom room)
    {
        for(int n = 0; n < room.contents.Count; n++)
        {
            Debug.Log($"{room.contents.Count},{n}");
            GameObject obj = Instantiate(room.contents[n], RoomContents.transform);
            room.contents[n] = obj; // �������̾��� contents�� �ν��Ͻ��� ��ü
            Vector2 pos = obj.transform.position;
            pos.x += n * 2.5f;
            obj.transform.position = pos;
        }
        if(room.roomType == RoomType.Battle)
        {
            battleManager.PrepareBattle(room);
        }
    }
}
