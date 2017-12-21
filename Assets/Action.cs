using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Action
{
    public string name;
    public uint manaCost;
    public uint damage;
    public bool isHealing;

    // Returns damage dealt
    public virtual uint UseAction(Character target, Character caster)
    {
        uint damageDealt = GetDamage();
        if (isHealing)
            target.Heal(damageDealt);
        else
        {
            damageDealt = (uint) (damageDealt * target.GetDefenseMultiplier());
            target.DealDamage(damageDealt);
        }
        DamageVisualizer.SpawnDamageText(target, damageDealt, isHealing);

        FinishAction();
        return damageDealt;
    }

    // Returns damage dealt
    public uint GetDamage()
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
}