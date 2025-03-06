using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour , IEquatable<Room>
{
    [SerializeField]
    protected int posX;
    [SerializeField]
    protected int posY;
    public int X => posX;
    public int Y => posY;

    public RoomType roomType;
    public List<GameObject> contents;

    protected List<Room> upRoom;
    protected List<Room> downRoom;

    public List<Room> UpRoom => upRoom;
    public List<Room> DownRoom => downRoom;

    protected virtual void Awake()
    {
        contents = new List<GameObject>();
        upRoom = new List<Room>();
        downRoom = new List<Room>();
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
        if(true) // TODO: (!Player.Instance.isBattle) 
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
    public void CopyNode(DungeonNode node, Room[,] room_arr)
    {
        posX = node.X;
        posY = node.Y;
        foreach(DungeonNode n in node.upRoom)
        {
            AddUpStair(room_arr[n.X, n.Y]);
            room_arr[n.X, n.Y].AddDownStair(this);
        }
    }
    public bool HasUpStair(Room other)
    {
        bool has = false;

        if (upRoom.Contains(other)) has = true;

        return has;
    }

    public void AddUpStair(Room up)
    {
        if(!upRoom.Contains(up)) upRoom.Add(up);
    }
    public void AddDownStair(Room down)
    {
        if (!downRoom.Contains(down)) downRoom.Add(down);
    }
    public void SubUpStair(Room up)
    {
        if (upRoom.Contains(up)) upRoom.Remove(up);
    }
    public void SubDownStair(Room down)
    {
        if (downRoom.Contains(down)) downRoom.Remove(down);
    }
    public bool Equals(Room other)
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
