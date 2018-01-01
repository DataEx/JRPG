using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public uint initialHealth;
    public uint initialMana;    
    protected uint currentHealth;
    protected uint currentMana;
    protected float defenseMultiplier = 1f;

    public enum CharacterPoses { Base, Attacking, Dead };
    public Animator animator; 

    public virtual void Awake() {
        currentHealth = initialHealth;
        currentMana = initialMana;
    }

    public virtual void DealDamage(uint damage) {
        currentHealth = currentHealth - damage;
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
        AnimateCharacter(CharacterPoses.Dead);
        BattleQueue.SetToRemoveCharacter(this);
    }

    public virtual void StartTurn(){}

    public void AnimateCharacter(CharacterPoses pose)
    {
        animator.SetTrigger(PoseToTrigger(pose));
    }

    string PoseToTrigger(CharacterPoses pose)
    {
        string trigger = "";

        switch (pose)
        {
            case CharacterPoses.Attacking:
                trigger = "UseAbility";
                break;
            case CharacterPoses.Base:
                trigger = "Return";
                break;
            case CharacterPoses.Dead:
                trigger = "Die";
                break;
        }
        return trigger;
    }
}
