using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    protected override void Picked()
    {
        base.Picked();
        GameManager.Instance.PickDiamond();
    }
}
