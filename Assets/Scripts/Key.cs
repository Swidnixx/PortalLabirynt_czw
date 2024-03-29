using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor { RedKey, GreenKey, GoldKey }

public class Key : Pickup
{
    public KeyColor color;

    protected override void Picked()
    {
        base.Picked();
        GameManager.Instance.AddKey(color);
    }
}
