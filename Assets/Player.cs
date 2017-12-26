using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
    public Action basicAttack;

    public PlayerInfoController playerInfo;

    public override void DealDamage(uint damage)
    {
        base.DealDamage(damage);
        playerInfo.DecreaseHealth(damage);
    }

    public override void Heal(uint healingDone)
    {
        base.Heal(healingDone);
        playerInfo.IncreaseHealth(healingDone);
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
        BattleQueue.Pop();
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
