using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Magic {

    public string name;
    public uint manaCost;
    public uint damage;
    public bool isHealing;

    // Returns damage dealt
    public virtual uint ActivateMagic(Character target) {
        uint damageDealt = GetDamage();

        // Apply damage to character
        if (isHealing)
            target.Heal(damageDealt);
        else
            target.DealDamage(damageDealt);

        return damageDealt;
    }

    uint GetDamage() {
        float rangePercentage = 0.1f; // 10% deviation from base damage
        float minDamage = damage * (1 - rangePercentage);
        float maxDamage = damage * (1 + rangePercentage);
        uint randomDamage = (uint) Mathf.Max(1,  Random.Range(minDamage, maxDamage));
        return randomDamage;

    }
}
