using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Status : IEquatable<Status>
{
    public int stack;
    public string description;
    protected string imagePath;
    public Image image = null;
    public Mortals host;
    public abstract void GetEffect();
    public abstract void LoseEffect();

    public bool Equals(Status other)
    {
        if (this.GetType() == other.GetType())
            return true;
        else return false;
    }
}
