using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int timeToAdd = 10;

    protected override void Picked()
    {
        base.Picked();
        GameManager.Instance.AddTime(timeToAdd);
    }
}
