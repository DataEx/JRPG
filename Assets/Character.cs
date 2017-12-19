using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public uint initialHealth;
    public uint initialMana;
    protected uint currentHealth;
    protected uint currentMana;

    void Awake() {
        currentHealth = initialHealth;
        currentMana = initialMana;
    }

    public virtual void DealDamage(uint damage) {
        currentHealth = currentHealth - damage;
        if (currentHealth > initialHealth)
            print(this.name + " is dead!");
    }

    public virtual void Heal(uint healingDone) {
        currentHealth = currentHealth + healingDone;
    }

    public uint GetCurrentHealth() {
        return currentHealth;
    }

    public uint GetCurrentMana()
    {
        return currentMana;
    }
}
