using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public uint initialHealth;
    public uint initialMana;
    protected uint currentHealth;
    protected uint currentMana;
    protected float defenseMultiplier = 1f;

    public enum CharacterPoses { Base, Attacking, Dead, Victory };
    public Animator animator;

    public virtual void Awake() {
        currentHealth = initialHealth;
        currentMana = initialMana;
    }

    public virtual bool DealDamage(uint damage) {
        bool isDestroyed = false;
        currentHealth = currentHealth - damage;
        if (currentHealth > initialHealth)
        {
            isDestroyed = true;
        }
        return isDestroyed;
    }

    public virtual void Heal(uint healingDone) {
        currentHealth = currentHealth + healingDone;
        currentHealth = (uint)Mathf.Min(currentHealth, initialHealth);
    }

    public virtual void HealMana(uint healingdone)
    {
        currentMana = currentMana + healingdone;
        currentMana = (uint)Mathf.Min(currentMana, initialMana);
    }

    public uint GetCurrentHealth() {
        return currentHealth;
    }
    public uint GetInitialHealth()
    {
        return initialHealth;
    }
    public uint GetCurrentMana()
    {
        return currentMana;
    }

    public float GetDefenseMultiplier()
    {
        return defenseMultiplier;
    }

    public void DestroySelf()
    {
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
            case CharacterPoses.Victory:
                trigger = "Victory";
                break;
        }
        return trigger;
    }
}
