using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    public Action basicAttack;
    public Action defendAction;

    public PlayerInfoController playerInfo;

    public override bool DealDamage(uint damage)
    {
        bool isDead = base.DealDamage(damage);
        playerInfo.DecreaseHealth(damage);
        return isDead;
    }

    public override void Heal(uint healingDone)
    {
        base.Heal(healingDone);
        playerInfo.IncreaseHealth(healingDone);
    }

    public override void HealMana(uint healingDone) {
        base.HealMana(healingDone);
        playerInfo.IncreaseMana(healingDone);
    }

    public bool HaveEnoughMana(uint manaCost)
    {
        return currentMana >= manaCost;
    }

    public void SpendMana(uint manaCost)
    {
        currentMana -= manaCost;
        playerInfo.DecreaseMana(manaCost);
    }
    public void Defend()
    {
        defenseMultiplier = 2f;
        defendAction.UseAction(this, this);
    }
    public void ResetDefense()
    {
        defenseMultiplier = 1f;
    }
    public override void StartTurn()
    {
        ResetDefense();
        playerInfo.inputController.ReturnToBaseMenu();
    }

}
