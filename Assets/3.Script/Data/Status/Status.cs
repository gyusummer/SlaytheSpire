using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : IEquatable<Status>
{
    public int stack;
    public string description;
    public string imagePath;
    public Mortals host;
    public abstract void GetEffect();

    public bool Equals(Status other)
    {
        if (this.GetType() == other.GetType())
            return true;
        else return false;
    }
}
