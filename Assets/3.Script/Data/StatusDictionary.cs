using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StatusDictionary
{
    public static Dictionary<Statuses, Type> Dict = new Dictionary<Statuses, Type>()
    {
        { Statuses.Vulnerable, typeof(Vulnerable) },
    };
}
