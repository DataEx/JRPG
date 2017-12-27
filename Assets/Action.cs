using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public string actionName;
    public uint manaCost;
    public uint damage;
    public bool isHealing;


    // Returns damage dealt
    public virtual void UseAction(Character target, Character caster)
    {
        uint damageDealt = GetDamage();
        if (isHealing)
            target.Heal(damageDealt);
        else
        {
            damageDealt = (uint) (damageDealt * (1f /target.GetDefenseMultiplier()));
            target.DealDamage(damageDealt);
        }
        print(caster + " dealt " + damageDealt + " damage to " + target);
        ActionDetails.DisplayDetails(caster, target, this);
        DamageVisualizer.SpawnDamageText(target, damageDealt, isHealing);
        AnimateAction(target);
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

    public virtual void FinishAction()
    {
        BattleQueue.Pop();
    }

    public virtual void AnimateAction(Character target)
    {
        FinishAction();
        // unique for each
        // when done, call finish action
    }
}