using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DungeonMaster : Singleton<DungeonMaster>
{
    public GameObject RoomContents;
    public BattleManger battleManager;
    public GameObject Transition_img;
    protected void Start()
    {
        Transition_img = GameObject.Find("Transition_img");
        //Transition_img.gameObject.SetActive(false);
    }
    public void PrepareRoom(Room room)
    {
        // TODO: 주석처리만 지우기
        Transition_img.transform.position = new Vector2(960, 1620);
        Transition_img.transform.DOMoveY(540, 1f)
            .OnStart(() =>
            {
                Transition_img.gameObject.SetActive(true);
            })
            .OnComplete(() =>
            {
                DungeonUIManager.Instance.ToggleMap();
                FillContents(room);
                TransitionOut();
            });
    }
    void FillContents(Room room)
    {
        for (int n = 0; n < room.contents.Count; n++)
        {
            //Debug.Log($"{room.contents.Count},{n}");
            GameObject obj = Instantiate(room.contents[n], RoomContents.transform);
            room.contents[n] = obj; // 프리팹이었던 contents를 인스턴스로 교체
            Vector2 pos = obj.transform.position;
            pos.x += n * 2.5f;
            obj.transform.position = pos;
        }
        if (room.roomType == RoomType.Battle || room.roomType == RoomType.Boss)
        {
            battleManager.PrepareBattle(room);
        }
    }
    void TransitionOut()
    {
        Transition_img.transform.position = new Vector2(960, 540);
        Transition_img.transform.DOMoveY(1620f, 1f).OnComplete(() =>
        {
            Transition_img.gameObject.SetActive(false);
        });
    }
}
