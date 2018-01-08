using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Action {

    public override uint GetDamage()
    {
        return damage;
    }
}
