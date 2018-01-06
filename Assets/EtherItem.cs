using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherItem : HealingItem {

    public override void UseAction(Character target, Character caster)
    {
        // InputController.staticCharacterPointer.SetTarget(target);
        this.caster = caster;
        this.target = target;
        damageDealt = GetDamage();
        targetIsDestroyed = false;
        target.HealMana(damageDealt);
        caster.AnimateCharacter(Character.CharacterPoses.Attacking);
        Invoke("AnimateAction", 0.6f); ActionDetails.ItemDisplayDetails(caster, target, this);
    }

}
