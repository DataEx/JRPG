using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialStrike : Magic
{
    public GameObject actionPrefab;
    GameObject instantiatedAction;
    bool actionActive = false;
    public override void AnimateAction()
    {
        instantiatedAction = Instantiate(actionPrefab);
        instantiatedAction.transform.position = target.transform.position + Vector3.up * 10;
        actionActive = true;
        StartCoroutine(DelayText(target));
    }

    IEnumerator DelayText(Character target)
    {
        yield return new WaitForSeconds(1f);
        DamageVisualizer.SpawnDamageText(target, damageDealt, isHealing);

    }

    void Update() {

        if (actionActive && instantiatedAction == null)
        {
            actionActive = false;
            FinishAction(caster);
        }
    } 
}
