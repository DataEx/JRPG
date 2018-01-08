using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public string actionName;
    public uint manaCost;
    public uint damage;
    public bool isHealing;

    protected uint damageDealt;

    protected Character target;
    protected Character caster;
    protected bool targetIsDestroyed = false;

    public string description;

    // Returns damage dealt
    public virtual void UseAction(Character target, Character caster)
    {
        // InputController.staticCharacterPointer.SetTarget(target);
        this.caster = caster;
        this.target = target;
        damageDealt = GetDamage();
        targetIsDestroyed = false;
        if (!isHealing) { 
            damageDealt = (uint) (damageDealt * (1f /target.GetDefenseMultiplier()));
        }
        caster.AnimateCharacter(Character.CharacterPoses.Attacking);
        Invoke("AnimateAction", 0.6f);
    }

    // Returns damage dealt
    public virtual uint GetDamage()
    {
        float rangePercentage = 0.1f; // 10% deviation from base damage
        float minDamage = damage * (1 - rangePercentage);
        float maxDamage = damage * (1 + rangePercentage);
        uint randomDamage = (uint)Mathf.Max(1, Random.Range(minDamage, maxDamage));
        return randomDamage;
    }

    public virtual void FinishAction(Character caster)
    {
        if (isHealing)
        {
            target.Heal(damageDealt);
        }
        else
        {
            targetIsDestroyed = target.DealDamage(damageDealt);
        }
        InputController.staticCharacterPointer.ResetCameraTransform();
        caster.AnimateCharacter(Character.CharacterPoses.Base);
        if (targetIsDestroyed)
            target.DestroySelf();
        BattleQueue.ResetState();
    }

    public virtual void AnimateAction()
    {
        FinishAction(caster);
        // unique for each
        // when done, call finish action
    }
}