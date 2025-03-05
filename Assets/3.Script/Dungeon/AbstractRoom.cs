using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbstractRoom : MonoBehaviour , IEquatable<AbstractRoom>
{
    [SerializeField]
    protected int posX;
    [SerializeField]
    protected int posY;
    public int X => posX;
    public int Y => posY;

    public RoomType roomType;
    public List<GameObject> contents;

    protected List<AbstractRoom> upRoom;
    protected List<AbstractRoom> downRoom;

    public List<AbstractRoom> UpRoom => upRoom;
    public List<AbstractRoom> DownRoom => downRoom;

    protected virtual void Awake()
    {
        contents = new List<GameObject>();
        upRoom = new List<AbstractRoom>();
        downRoom = new List<AbstractRoom>();
    }
    protected void Start()
    {
        if(TryGetComponent(out Button butt))
        {
            butt.onClick.AddListener(EnterPlayer);
        }
    }

    public void Init(int x, int y)
    {
        posX = x;
        posY = y;
    }
    public virtual void EnterPlayer()
    {
        if(true) // TODO: if (!Player.Instance.isBattle) 테스트용이니 수정할것
        {
            if(true) //(downRoom.Contains(Player.Instance.curRoom))
            {
                DrawCircle();
                Player.Instance.curRoom = this;
                DungeonMaster.Instance.PrepareRoom(this);
            }
        }
    }
    protected virtual void DrawCircle()
    {
        GameObject child = transform.GetChild(1).gameObject;
        child.SetActive(true);
        child.TryGetComponent(out Animator anim);
        anim.SetTrigger("Enter");
    }
    public void CopyNode(DungeonNode node, AbstractRoom[,] room_arr)
    {
        posX = node.X;
        posY = node.Y;
        foreach(DungeonNode n in node.upRoom)
        {
            AddUpStair(room_arr[n.X, n.Y]);
            room_arr[n.X, n.Y].AddDownStair(this);
        }
    }
    public bool HasUpStair(AbstractRoom other)
    {
        bool has = false;

        if (upRoom.Contains(other)) has = true;

        return has;
    }

    public void AddUpStair(AbstractRoom up)
    {
        if(!upRoom.Contains(up)) upRoom.Add(up);
    }
    public void AddDownStair(AbstractRoom down)
    {
        if (!downRoom.Contains(down)) downRoom.Add(down);
    }
    public void SubUpStair(AbstractRoom up)
    {
        if (upRoom.Contains(up)) upRoom.Remove(up);
    }
    public void SubDownStair(AbstractRoom down)
    {
        if (downRoom.Contains(down)) downRoom.Remove(down);
    }
    public bool Equals(AbstractRoom other)
    {
        if (posX == other.posX && posY == other.posY)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
