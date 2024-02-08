using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int freezeTime = 10;

    protected override void Picked()
    {
        base.Picked();
        GameManager.Instance.FreezeTime(freezeTime);
    }
}
