using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    public Action[] actions;

    public override void StartTurn()
    {
        SelectRandomAttack();
    }

    void SelectRandomAttack()
    {
        int actionIndex = Random.Range(0, actions.Length);
        int playerIndex = Random.Range(0, BattleQueue.players.Count);
        Player target = BattleQueue.players[playerIndex];
        Action action = actions[actionIndex];
        action.UseAction(target, this);

//        Need to find way to say "I'm done with turn" --> Call Pop on Queue
    }

}
