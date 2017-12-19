using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    public PlayerInfoController playerInfo;

    public override void DealDamage(uint damage)
    {
        base.DealDamage(damage);
        
    }

    public override void Heal(uint healingDone)
    {
        base.Heal(healingDone);
    }


}
