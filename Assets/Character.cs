using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public uint initialHealth;
    public uint initialMana;    
    protected uint currentHealth;
    protected uint currentMana;
    protected float defenseMultiplier = 1f;
    public Action basicAttack;

    void Awake() {
        currentHealth = initialHealth;
        currentMana = initialMana;

    }

    public virtual void DealDamage(uint damage) {
        currentHealth = currentHealth - damage;
        print("Current health: " + currentHealth);
        if (currentHealth > initialHealth)
        {
            DestroySelf();
        }
        print(this.name + "Health: " + this.currentHealth + " / " + this.initialHealth);
    }

    public virtual void Heal(uint healingDone) {
        currentHealth = currentHealth + healingDone;
        currentHealth = (uint)Mathf.Min(currentHealth, initialHealth);
        print(this.name + "Health: " + this.currentHealth + " / " + this.initialHealth);
    }

    public uint GetCurrentHealth() {
        return currentHealth;
    }

    public uint GetCurrentMana()
    {
        return currentMana;
    }

    public float GetDefenseMultiplier()
    {
        return defenseMultiplier;
    }

    void DestroySelf()
    {
        print(this.name + " is dead!");
        BattleQueue.RemoveCharacter(this);
        Destroy(this.gameObject, 0.25f);
    }

    public virtual void StartTurn(){}
}
